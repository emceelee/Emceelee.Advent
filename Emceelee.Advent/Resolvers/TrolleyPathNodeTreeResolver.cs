using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Emceelee.Advent.Resolvers
{
    public class TrolleyPathNodeTreeResolver
    {
        //Take the list of nodes
        public TrolleyPathNode ResolveTrolleyPathNodeTree(IList<TrolleyPath> remainingPaths)
        {
            var pathStarts = remainingPaths.Select(path => path.Start).Distinct();
            var pathEnds = remainingPaths.Select(path => path.End);
            //find any starts that aren't part of another path
            var rootStarts = pathStarts.Where(start => !pathEnds.Contains(start));
            if (!rootStarts.Any())
            {
                throw new ArgumentException("No root node detected");
            }
            if (rootStarts.Count() > 1)
            {
                throw new ArgumentException("Multiple root nodes detected");
            }
            var rootStart = rootStarts.FirstOrDefault();
            var startingPath = new TrolleyPath(rootStart, rootStart);
            var rootNode = new TrolleyPathNode(null, startingPath);

            //find paths downstream of parent node
            var downstreamPaths = remainingPaths.Where(path => path.Start == rootNode.NodeName).ToList();
            foreach(var downstreamPath in downstreamPaths)
            {
                remainingPaths.Remove(downstreamPath);
            }
            foreach(var downstreamPath in downstreamPaths)
            {
                rootNode.TraverseDownstreamPath(downstreamPath, remainingPaths);
            }
            if(remainingPaths.Any())
            {
                throw new InvalidOperationException("There are remaining paths after traversing and building node tree");
            }

            return rootNode;
        }
    }

    [DebuggerDisplay("NodeName = {NodeName}, NodeValue = {NodeValue}, PathToNodeValue = {PathToNodeValue}")]
    public class TrolleyPathNode
    {
        public TrolleyPathNode(TrolleyPathNode parent, TrolleyPath path)
        {
            Parent = parent;
            Children = new List<TrolleyPathNode>();
            NodeName = path.End;
            NodeValue = path.Value;

            if(Parent != null)
            {
                if(parent[NodeName] != null)
                {
                    throw new InvalidOperationException($"Child Node {NodeName} already exists");
                }
                Parent.Children.Add(this);
            }
        }

        public TrolleyPathNode Parent { get; }
        public IList<TrolleyPathNode> Children { get; }
        public string NodeName { get; }
        public int NodeValue { get; }
        public int PathToNodeValue
        {
            get
            {
                var value = NodeValue;
                var currentParent = Parent as TrolleyPathNode;

                while(currentParent != null)
                {
                    value += currentParent.NodeValue;
                    currentParent = currentParent.Parent as TrolleyPathNode;
                }
                return value;
            }
        }

        public void TraverseDownstreamPath(TrolleyPath currentPath, IList<TrolleyPath> remainingPaths)
        {
            var downstreamNode = new TrolleyPathNode(this, currentPath);

            //find paths downstream of downstream node
            var downstreamPaths = remainingPaths.Where(path => path.Start == downstreamNode.NodeName).ToList();
            foreach (var downstreamPath in downstreamPaths)
            {
                remainingPaths.Remove(downstreamPath);
            }
            foreach (var downstreamPath in downstreamPaths)
            {
                downstreamNode.TraverseDownstreamPath(downstreamPath, remainingPaths);
            }
        }

        public TrolleyPathNode this[string name]
        {
            get
            {
                var match = this.Children.FirstOrDefault(child => child.NodeName == name);
                return match;
            }
        }
    }

    [DebuggerDisplay("Start = {Start}, End = {End}, Obstacles = {Obstacles}, Value = {Value}")]
    public class TrolleyPath
    {
        public TrolleyPath(string start, string end, string obstacles = null)
        {
            Start = start;
            End = end;
            Obstacles = obstacles;
        }

        public string Start { get; }
        public string End { get; }
        public string Obstacles { get; }
        public int Value
        {
            get
            {
                var elves = Obstacles?.Count(k => k == 'E') ?? 0;
                var seals = Obstacles?.Count(k => k == 'S') ?? 0;

                return 3 * elves + seals;
            }
        }

    }
}
