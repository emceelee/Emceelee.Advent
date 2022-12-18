using System;
using System.Collections.Generic;
using System.Text;

namespace Emceelee.Advent.Transforms
{
    public interface ITransform<T>
    {
        bool ApplyTransform(T[,] map, int x, int y, out T nextState);
    }

    public class AggregateTransform<T> : ITransform<T>
    {
        public List<ITransform<T>> Transformers = new List<ITransform<T>>();

        public void AddTransform(ITransform<T> transformer)
        {
            if(!this.Transformers.Contains(transformer))
            {
                this.Transformers.Add(transformer);
            }
        }

        public bool ApplyTransform(T[,] map, int x, int y, out T nextState)
        {
            nextState = map[x, y]; //return current state as default

            foreach (var transformer in this.Transformers)
            {
                if(transformer.ApplyTransform(map, x, y, out T nextStateTemp))
                {
                    nextState = nextStateTemp;
                    return true;
                }
            }
            return false;
        }

        public T[,] ApplyTransform(T[,] map)
        {
            var nextMap = new T[map.GetLength(0), map.GetLength(1)];

            for(int x = 0; x < map.GetLength(0); ++x)
            {
                for (int y = 0; y < map.GetLength(0); ++y)
                {
                    ApplyTransform(map, x, y, out T nextState);
                    nextMap[x, y] = nextState;
                }
            }

            return nextMap;
        }

        public T[,] ApplyTransform(T[,] map, int iterations)
        {
            if(iterations == 0)
            {
                return map;
            }

            var nextMap = ApplyTransform(map);
            return ApplyTransform(nextMap, iterations - 1);
        }
    }
}
