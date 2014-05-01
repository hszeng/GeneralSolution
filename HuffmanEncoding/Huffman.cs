using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Introduction2Algorithms.DataStructure;

namespace Introduction2Algorithms.HuffmanEncoding
{
    public class Huffman
    {
        private List<HuffmanNode> originalNodes;
        private HuffmanNode rootNode;
        public Huffman(IEnumerable<KeyValuePair<char, int>> kvps)
        {
            //保存原始数据
            var tmpOriginalNodes = from kvp in kvps select new HuffmanNode(kvp.Key, kvp.Value);
            //创建最小优先队列,并输入数据
            MinPriorityQueue<HuffmanNode> minQueue = new MinPriorityQueue<HuffmanNode>();
            originalNodes = new List<HuffmanNode>();
            foreach (var node in tmpOriginalNodes)
            {
                originalNodes.Add(node);
                minQueue.Insert(node);
            }
            //建造编码树，并取得编码树的根节点
            while (!minQueue.IsEmpty)
            {
                HuffmanNode left = minQueue.ExtractMin();
                if (minQueue.IsEmpty)
                {
                    rootNode = left;
                    break;
                }
                HuffmanNode right = minQueue.ExtractMin();
                HuffmanNode newNode = new HuffmanNode(null, left.Value + right.Value, left, right);
                left.Parent = newNode;
                right.Parent = newNode;
                minQueue.Insert(newNode);
            }
        }
        //只接受单个char的加密
        public string Encode(char sourceChar)
        {
            HuffmanNode hn = originalNodes.FirstOrDefault(n => n.Key == sourceChar);
            if (hn == null) return null;
            HuffmanNode parent = hn.Parent;
            StringBuilder rtn = new StringBuilder();
            while (parent != null)
            {
                if (Object.ReferenceEquals(parent.Left, hn))//左孩子，编码为0
                {
                    rtn.Insert(0, "0", 1);
                }
                else//右孩子，编码为1
                {
                    rtn.Insert(0, "1", 1);
                }
                hn = parent;
                parent = parent.Parent;
            }
            return rtn.ToString();
        }
        //只接受一个字符的解码输出
        public bool Decode(string string01, out char? output)
        {
            HuffmanNode tmpNode = rootNode;
            char[] chars = string01.Trim().ToCharArray();
            for (int i = 0; i < chars.Count(); i++)
            {
                if (chars[i] == '0') tmpNode = tmpNode.Left;
                if (chars[i] == '1') tmpNode = tmpNode.Right;
            }
            if (tmpNode != null && tmpNode.Left == null && tmpNode.Right==null)
            {
                output = tmpNode.Key;
                return true;
            }
            else
            {
                output = null;
                return false;
            }
        }

        class HuffmanNode : IHeapValue
        {
            public HuffmanNode(char? key, int value, HuffmanNode left = null, HuffmanNode right = null)
            {
                this.Left = left;
                this.Right = right;
                this.Key = key;
                this.Value = value;
            }
            public HuffmanNode Left { get; private set; }
            public HuffmanNode Right { get; private set; }
            public HuffmanNode Parent { get; set; }
            public char? Key { get; private set; }
            public int Value { get; set; }
        }
    }
}
