using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniTests.SummerTests2021
{
    public class Task176PrefiksnoeDerevo: ITest
    {
        public class TrieNode
        {
            readonly Dictionary<char, TrieNode> _children = new ();
            public bool IsEndkey { get; set; }
            
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
            TrieNode _root = new();

            public void Insert(string word)
            {
                var i = 0;
                var currentNode = _root;
                while (true)
                {
                    var child = currentNode[word[i]];
                    if (null == child)
                    {
                        currentNode[word[i]] = new TrieNode();
                        if (i == word.Length - 1)
                        {
                            currentNode[word[i]].IsEndkey = true;
                            break;
                        }
                        currentNode = currentNode[word[i]];
                        i++;
                        continue;
                    }

                    if (i == word.Length - 1)
                    {
                        child.IsEndkey = true;
                        break;
                    }

                    currentNode = child;
                    i++;
                }
            }

            public bool Search(string word)
            {
                var i = 0;
                var currentNode = _root;
                while (true)
                {
                    var child = currentNode[word[i]];
                    if (null == child)
                    {
                        return false;
                    }

                    if (i == word.Length - 1)
                    {
                        return child.IsEndkey;
                    }

                    currentNode = child;
                    i++;
                }
            }

            public bool StartsWith(string prefix)
            {
                var i = 0;
                var currentNode = _root;
                while (true)
                {
                    var child = currentNode[prefix[i]];
                    if (null == child)
                    {
                        return false;
                    }

                    if (i == prefix.Length - 1)
                    {
                        return true;
                    }

                    currentNode = child;
                    i++;
                }
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