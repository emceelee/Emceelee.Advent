using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Resolvers
{
    public class NodeNetworkResolver
    {
        private Dictionary<string, MinPathResult> MinPathCache { get; } = new Dictionary<string, MinPathResult>();
        public List<NetworkNode> Nodes { get; } = new List<NetworkNode>();

        public NetworkNode AddNode(string name)
        {
            if (Contains(name))
            {
                throw new InvalidOperationException("Node already exists");
            }
            var node = new NetworkNode(name);
            Nodes.Add(node);

            return node;
        }

        public void AddPath(string nodeName1, string nodeName2, int pathValue)
        {
            if (!this.Contains(nodeName1))
            {
                throw new InvalidOperationException($"Add node {{{nodeName1}}} to Network before adding a path that contains it.");
            }
            if (!this.Contains(nodeName2))
            {
                throw new InvalidOperationException($"Add node {{{nodeName2}}} to Network before adding a path that contains it.");
            }
            if (pathValue < 0)
            {
                throw new ArgumentOutOfRangeException($"Path value can't be negative");
            }

            var node1 = this[nodeName1];
            var node2 = this[nodeName2];

            var path = new NetworkPath(node1, node2, pathValue);
            node1.AddPath(path);
            node2.AddPath(path);
        }
        
        //start caching from ending node so we can quickly retrieve results for later parts of paths when generating earlier cache results
        public void CacheMinPathValues(string end)
        {
            var remainingNodes = this.Nodes.ToList();
            var endNode = this[end];
            remainingNodes.Remove(endNode);

            foreach (var path in endNode.Paths)
            {
                var fromNode = path.GetOtherNode(endNode);
                if (remainingNodes.Contains(fromNode))
                {
                    remainingNodes.Remove(fromNode);
                }
                var minPathValue = ResolveMinimumPathValue(fromNode.Name, endNode.Name, out IEnumerable<NetworkPath> minValuePath);
                var cacheKey = PathHelper.GenerateCacheKey(fromNode.Name, end);

                if (!MinPathCache.ContainsKey(cacheKey))
                {
                    MinPathCache.Add(cacheKey, new MinPathResult() { Key = cacheKey, MinValue = minPathValue, MinValuePath = minValuePath });
                }

                CacheMinPathValues(fromNode, end, remainingNodes);
            }
        }

        public void CacheMinPathValues(NetworkNode prevNode, string end, List<NetworkNode> remainingNodes)
        {
            var endNode = this[end];

            var remainingPaths = prevNode.Paths.Where(path => remainingNodes.Contains(path.GetOtherNode(prevNode)));
            if(!remainingPaths.Any())
            {
                return;
            }

            foreach (var path in remainingPaths)
            {
                var fromNode = path.GetOtherNode(prevNode);
                if (remainingNodes.Contains(fromNode))
                {
                    remainingNodes.Remove(fromNode);
                }
                var minPathValue = ResolveMinimumPathValue(fromNode.Name, endNode.Name, out IEnumerable<NetworkPath> minValuePath);
                var cacheKey = PathHelper.GenerateCacheKey(fromNode.Name, end);

                if (!MinPathCache.ContainsKey(cacheKey))
                {
                    MinPathCache.Add(cacheKey, new MinPathResult() { Key = cacheKey, MinValue = minPathValue, MinValuePath = minValuePath });
                }

                CacheMinPathValues(fromNode, end, remainingNodes);
            }
        }

        public int? ResolveMinimumPathValue(string nodeName1, string nodeName2, out IEnumerable<NetworkPath> minValuePath)
        {
            var cacheKey = PathHelper.GenerateCacheKey(nodeName1, nodeName2);
            if(MinPathCache.TryGetValue(cacheKey, out MinPathResult cacheResult))
            {
                minValuePath = cacheResult.MinValuePath;
                return cacheResult.MinValue;
            }

            if (nodeName1 == nodeName2)
            {
                minValuePath = Enumerable.Empty<NetworkPath>();
                return 0;
            }

            var start = this[nodeName1];

            var value = start.ResolveMinValuePath(nodeName2, MinPathCache, out minValuePath);
            return value;
        }

        public NetworkNode this[string name]
        {
            get
            {
                var match = this.Nodes.FirstOrDefault(nodes => nodes.Name == name);
                return match;
            }
        }

        public bool Contains(string name)
        {
            return this[name] != null;
        }
    }

    [DebuggerDisplay("Name = {Name}")]
    public class NetworkNode
    {
        public NetworkNode(string name)
        {
            Name = name;
        }

        public IList<NetworkPath> Paths { get; } = new List<NetworkPath>();
        public string Name { get; }

        public void AddPath(NetworkPath path)
        {
            if(!path.ContainsNode(this))
            {
                throw new InvalidOperationException($"Path does not contain node {Name}");
            }
            if(Paths.Any(existing => existing.Equals(path)))
            {
                throw new InvalidOperationException($"Path {{{ToString()}}} already exists for node {Name}");
            }
            Paths.Add(path);
        }

        //Only called for start node
        public int? ResolveMinValuePath(string end, Dictionary<string, MinPathResult> minPathCache, out IEnumerable<NetworkPath> minValuePath)
        {
            var cacheKey = PathHelper.GenerateCacheKey(this.Name, end);
            if (minPathCache.TryGetValue(cacheKey, out MinPathResult cacheResult))
            {
                minValuePath = cacheResult.MinValuePath;
                return cacheResult.MinValue;
            }

            int? minValue = null;
            IEnumerable<NetworkPath> minValuePathTemp = null;

            foreach (var path in Paths)
            {
                var traversedPath = new List<NetworkNode>() { this };
                var pathValue = path.ResolveMinValuePath(this, end, traversedPath, minPathCache, out IEnumerable <NetworkPath> pathMinValuePath);

                if (pathValue != null && pathMinValuePath.Any())
                {
                    if (minValue == null || pathValue.Value < minValue)
                    {
                        minValue = pathValue.Value;
                        minValuePathTemp = pathMinValuePath;
                    }
                }
            }
            
            if (minValue != null)
            {
                minValuePath = minValuePathTemp;
                return minValue;
            }

            //return nothing if all paths terminate without finding endpoint
            minValuePath = Enumerable.Empty<NetworkPath>();
            return null;
        }
    }

    [DebuggerDisplay("Node1 = {Node1.Name}, Node2 = {Node2.Name}, PathValue = {PathValue}")]
    public class NetworkPath
    {
        public NetworkNode Node1 { get; }
        public NetworkNode Node2 { get; }
        public int PathValue { get; }

        public NetworkPath(NetworkNode node1, NetworkNode node2, int pathValue)
        {
            Node1 = node1;
            Node2 = node2;
            PathValue = pathValue;
        }

        public bool ContainsNode(NetworkNode node)
        {
            return node == Node1 || node == Node2;
        }

        public NetworkNode GetOtherNode(NetworkNode node)
        {
            if(node == Node1)
            {
                return Node2;
            }
            else if(node == Node2)
            {
                return Node1;
            }
            throw new InvalidOperationException("node does not belong to path");
        }

        public bool Equals(NetworkPath other)
        {
            return (other.Node1.Name == this.Node1.Name && other.Node2.Name == this.Node2.Name) ||
                (other.Node1.Name == this.Node2.Name && other.Node2.Name == this.Node1.Name);
        }

        public override string ToString()
        {
            return $"{Node1.Name}-{Node2.Name}: {PathValue}";
        }

        public int? ResolveMinValuePath(NetworkNode prev, string end, IEnumerable<NetworkNode> traversedPath, Dictionary<string, MinPathResult> minPathCache, out IEnumerable<NetworkPath> minValuePath)
        {
            var cacheKey = PathHelper.GenerateCacheKey(prev.Name, end);
            if (minPathCache.TryGetValue(cacheKey, out MinPathResult cacheResult))
            {
                minValuePath = cacheResult.MinValuePath;
                return cacheResult.MinValue;
            }

            var next = this.GetOtherNode(prev);
            //end found - return current path as the start of this viable path
            if(next.Name == end)
            {
                minValuePath = new List<NetworkPath>() { this };
                return PathValue;
            }

            //prevent circular paths
            var remainingPaths = next.Paths.Where(path => !traversedPath.Any(node => path.ContainsNode(node)));
            if(!remainingPaths.Any())
            {
                //return nothing if path terminates without finding endpoint
                minValuePath = Enumerable.Empty<NetworkPath>();
                return null;
            }

            int? minValue = null;
            IEnumerable<NetworkPath> minValuePathTemp = null;

            foreach (var remainingPath in remainingPaths)
            {
                var nextTraversedPath = traversedPath.ToList();
                nextTraversedPath.Add(next);
                var pathValue = remainingPath.ResolveMinValuePath(next, end, nextTraversedPath, minPathCache, out IEnumerable<NetworkPath> pathMinValuePath);

                if(pathValue != null)
                {
                    if(minValue == null || pathValue.Value < minValue)
                    {
                        minValue = pathValue.Value;
                        minValuePathTemp = pathMinValuePath;
                    }
                }
            }

            if(minValue != null)
            {
                var minValuePathList = new List<NetworkPath>() { this };
                minValuePathList.AddRange(minValuePathTemp);
                minValuePath = minValuePathList;
                return minValue + PathValue;
            }
            
            //return nothing if all paths terminate without finding endpoint
            minValuePath = Enumerable.Empty<NetworkPath>();
            return null;
        }
    }

    [DebuggerDisplay("Key = {Key}, MinValue = {MinValue}")]
    public class MinPathResult
    {
        public string Key { get; set; }
        public int? MinValue { get; set; }
        public IEnumerable<NetworkPath> MinValuePath { get; set; }
    }

    public static class PathHelper
    {
        public static string GenerateCacheKey(string start, string end)
        {
            return $"{start}->{end}";
        }
    }
}
