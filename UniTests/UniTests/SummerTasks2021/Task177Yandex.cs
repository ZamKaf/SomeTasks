using System;
using System.Collections.Generic;
using System.Linq;

namespace UniTests.SummerTasks2021
{
    public class Task177Yandex : ITest
    {
        public record Phrase
        {
            public string Text { get; set; }
            public int Count { get; set; }
        }
        
        public class AutocompleteSystem
        {
            public const char EnterChar = '#';
            public const int NumberOfReturnedLines = 3;
            readonly Trie _trie = new();
            string _inputText = "";
            public AutocompleteSystem(string[] strings, int[] times)
            {
                if (strings.Length != times.Length)
                    throw new ArgumentException();
                
                for (var i = 0; i < strings.Length; i++)
                {
                    _trie.Insert(strings[i], times[i]);
                }
            }

            public IList<string> Input(char c)
            {
                if (EnterChar == c)
                {
                    _trie.Insert(_inputText);
                    _inputText = "";
                    return new List<string>();
                }

                _inputText += c;
                
                var prefixPhrases = _trie.GetPhrases(_inputText);
                
                return 0 == prefixPhrases.Count 
                    ? new List<string>() :
                    GetMostFrequent(prefixPhrases, NumberOfReturnedLines).Select(p => p.Text).ToList();
            }
            
            IEnumerable<Phrase> GetMostFrequent(List<Phrase> phrases, int count)
            {
                if (phrases.Count <= count)
                {
                    phrases.Sort(Sort);
                    return phrases;
                }

                var result = new List<Phrase>(4);

                for (var i = 0; i < phrases.Count; i++)
                {
                    if (i < count)
                    {
                        result.Add(phrases[i]);
                        continue;
                    }
                    
                    if (i == count)
                        result.Sort(Sort);

                    var current = phrases[i];

                    var min = result.First();
                    if (min.Count < current.Count)
                    {
                        result.RemoveAt(0);
                        result.Add(current);
                        result.Sort(Sort);
                    }
                }
                
                return result;
            }

            int Sort(Phrase phrase, Phrase phrase1)
            {
                if (phrase.Count == phrase1.Count) 
                    return 0;
                return phrase.Count < phrase1.Count ? 1 : -1;
            }
        }
        
        public class TrieNode
        {
            readonly Dictionary<char, TrieNode> _children = new ();
            
            /// 4 keys only, cant be <0;
            public int NumberOfUses
            {
                get => _numberOfUses; 
                set => _numberOfUses = (value < 0) ? 0 : value;
            }

            public bool IsEndKey
            {
                get => _numberOfUses > 0;
                set => _numberOfUses = value ? 1 : 0;
            }

            int _numberOfUses = 0;
            
            public TrieNode() {}

            public bool HasChildren => _children.Keys.Count > 0;

            public IEnumerable<char> Keys => _children.Keys;

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

            public void Insert(string word, int count = 0)
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

                if (0 == count)
                    currentNode.NumberOfUses++;
                else
                    currentNode.NumberOfUses = count;    
            }

            public List<Phrase> GetPhrases(string prefix)
            {   
                var currentNode = _root;

                foreach (var child in prefix.Select(letter => currentNode[letter]))
                {
                    if (null == child)
                        return new List<Phrase>();
                    currentNode = child;
                }
                
                return GetSubPhrases(prefix, currentNode);
            }

            List<Phrase> GetSubPhrases(string prefix, TrieNode node)
            {
                var result = new List<Phrase>();
                if (node.IsEndKey)
                    result.Add(new Phrase{Text = prefix, Count = node.NumberOfUses});

                if (!node.HasChildren) 
                    return result;
                
                foreach (var key in node.Keys)
                {
                    result.AddRange(GetSubPhrases(prefix+key, node[key]));
                }

                return result;
            }
        }
        
        public void Run()
        {
            var strings = new[] { "carqwe15", "carewq18", "crewq17", "bdsa10", "btre67", "bytw32", "hcgfss4", "cpou11" };
            var counts = new[] { 15, 18, 17, 10, 67, 32, 4, 11 };
            var system = new AutocompleteSystem(strings, counts);
            var inputTest = "";
            foreach (var letter in "ca#bd")
            {
                inputTest = letter == AutocompleteSystem.EnterChar ? "" : inputTest + letter;
                Console.WriteLine($"input text '{inputTest}':");
                foreach (var record in system.Input(letter))
                {
                    Console.WriteLine(record);
                }   
            }
            /*
            var t = new Trie();
            t.Insert("car");
            t.Insert("cat", 17);
            t.Insert("cater");
            t.Insert("caasdr", 4);
            t.Insert("coll", 4);
            var p = t.GetPhrases("ca");
            foreach (var phrase in p)
            {
                Console.WriteLine($"{phrase.Text} - {phrase.Count}");
            }
            */
        }
    }
}