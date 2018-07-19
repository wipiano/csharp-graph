using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    /// <summary>
    /// 自己ループを持たない重みなし有限無向グラフの隣接行列
    /// </summary>
    public class AdjacencyMatrix
    {
        // 要素数は n ^ 2 ではなく (n - 1)! で済むためジャグ配列をつかう
        private readonly bool[][] _graph;

        public AdjacencyMatrix(int nodeCount)
        {
            _graph = new bool[nodeCount - 1][];
            for (var i = 0; i < nodeCount - 1; i++)
            {
                _graph[i] = new bool[nodeCount - 1 - i];
            }
        }

        /// <summary>
        /// 指定されたノードどうしが隣接しているかどうか
        /// </summary>
        public bool IsNeighboring(int x, int y)
        {
            return Get(x, y);
        }

        /// <summary>
        /// x と y を接続します
        /// </summary>
        public void Connect(int x, int y)
        {
            SetValue(x, y, true);
        }

        /// <summary>
        /// x と y を切断します
        /// </summary>
        public void Disconnect(int x, int y)
        {
            SetValue(x, y, false);
        }


        /// <summary>
        /// x, y の位置の値を取得します。
        /// </summary>
        private bool Get(int x, int y)
        {
            // swap
            if (x > y)
            {
                (x, y) = (y, x);
            }

            if (x == y)
            {
                // 自己ループを持たないので false
                return false;
            }
            
            return _graph[x][y + CalcOffset(x)];
        }

        private void SetValue(int x, int y, bool v)
        {
            // swap
            if (x > y)
            {
                (x, y) = (y, x);
            }

            if (x == y)
            {
                return;
            }

            _graph[x][y + CalcOffset(x)] = v;
        }

        private int CalcOffset(int x) => - x - 1;
        
        public override string ToString()
        {
            var sb = new StringBuilder();
            var nodeCount = _graph.Length + 1;

            // header
            sb.AppendLine($" |{string.Join("|", Enumerable.Range(0, nodeCount))}|");
            
            for (var i = 0; i < nodeCount; i++)
            {
                sb.Append(i);
                
                // 実際の値
                for (var j = 0; j < nodeCount; j++)
                {
                    sb.Append("|");
                    sb.Append(IsNeighboring(i, j) ? "o" : "x");
                }

                sb.AppendLine("|");
            }

            return sb.ToString();
        }
    }
}