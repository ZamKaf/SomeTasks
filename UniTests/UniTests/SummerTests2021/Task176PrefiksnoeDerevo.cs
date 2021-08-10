using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UniTests.SummerTests2021
{
    public class Task176PrefiksnoeDerevo: ITest
    {
        public class TrieNode
        {
            readonly Dictionary<char, TrieNode> _children = new ();
            public bool IsEndKey { get; set; }
            
            public bool ContainsChild(char letter)
            {
                return _children.ContainsKey(letter);
            }

            public TrieNode this[char letter]
            {
                get => _children.ContainsKey(letter) ? _children[letter] : null;
                set => _children[letter] = value;
            }
        }
        
        public class Trie
        {
            readonly TrieNode _root = new();

            public void Insert(string word)
            {
                var currentNode = _root;
                var len = word.Length;
                for(var i = 0; i < len; i++)
                {
                    var letter = word[i];
                    if (!currentNode.ContainsChild(letter))
                        currentNode[word[i]] = new TrieNode();
                    currentNode = currentNode[word[i]];
                }

                currentNode.IsEndKey = true;
            }

            public bool Search(string word)
            {
                var currentNode = _root;
                foreach (var child in word.Select(letter => currentNode[letter]))
                {
                    if (null == child)
                        return false;

                    currentNode = child;
                }

                return currentNode.IsEndKey;
            }

            public bool StartsWith(string prefix)
            {
                var currentNode = _root;

                foreach (var child in prefix.Select(letter => currentNode[letter]))
                {
                    if (null == child)
                        return false;
                    
                    currentNode = child;
                }

                return true;
            }
        }
        
        public void Run()
        {
            var t = new Trie();
            t.Insert("car");
            t.Insert("wood");
            t.Insert("key");
            Console.WriteLine($"contains car {t.Search("car")}");
            Console.WriteLine($"contains wood {t.Search("wood")}");
            Console.WriteLine($"contains test {t.Search("test")}");
            Console.WriteLine($"starts with woo {t.StartsWith("woo")}");
            Console.WriteLine($"starts with c {t.StartsWith("c")}");
            Console.WriteLine($"starts with te {t.StartsWith("te")}");
        }
    }
}