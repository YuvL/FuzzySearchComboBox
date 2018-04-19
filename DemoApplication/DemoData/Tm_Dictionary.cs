using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoApplication.DemoData
{
    public class Tm_Dictionary
    {
        private List<Tm_DictionaryItem> m_Dictionary;
        private readonly SortedList<int, string> m_Id2Value;
        private readonly SortedList<string, int> m_Value2Id;
        private readonly SortedList<string, int> m_ValueForCheck2Id;

        public List<Tm_DictionaryItem> Dictionary
        {
            get
            {
                return m_Dictionary;
            }
        }

        public Tm_Dictionary()
        {
            m_Dictionary = new List<Tm_DictionaryItem>();
            m_Id2Value = new SortedList<int, string>();
            m_Value2Id = new SortedList<string, int>();
            m_ValueForCheck2Id = new SortedList<string, int>();
        }

        public Tm_Dictionary(List<Tm_DictionaryItem> dictionaryList)
        {
            m_Dictionary = new List<Tm_DictionaryItem>();
            m_Id2Value = new SortedList<int, string>();
            m_Value2Id = new SortedList<string, int>();
            m_ValueForCheck2Id = new SortedList<string, int>();

            Load(dictionaryList);
        }

        public void Load(List<Tm_DictionaryItem> dictionaryList)
        {
            if (dictionaryList == null)
            {
                m_Dictionary = new List<Tm_DictionaryItem>();
                return;
            }

            m_Dictionary = dictionaryList;
            foreach (Tm_DictionaryItem item in m_Dictionary)
            {
                if (!m_ValueForCheck2Id.ContainsKey(item.strValue.ToUpperInvariant()))
                    m_ValueForCheck2Id.Add(item.strValue.ToUpperInvariant(), item.nId);

                if (m_Value2Id.ContainsKey(item.strValue))
                    continue;

                m_Value2Id.Add(item.strValue, item.nId);
                m_Id2Value.Add(item.nId, item.strValue);
            }
        }

        public void AddValue(Tm_DictionaryItem item)
        {
            if (!m_Id2Value.ContainsKey(item.nId) && !m_Value2Id.ContainsKey(item.strValue))
            {
                m_Dictionary.Add(item);
                m_Value2Id.Add(item.strValue, item.nId);
                m_Id2Value.Add(item.nId, item.strValue);
                if (!m_ValueForCheck2Id.ContainsKey(item.strValue.ToUpperInvariant()))
                    m_ValueForCheck2Id.Add(item.strValue.ToUpperInvariant(), item.nId);
            }
        }

        public int? GetIdByValue(string strValue)
        {
            if (strValue != null && m_ValueForCheck2Id.ContainsKey(strValue.ToUpperInvariant()))
                return m_ValueForCheck2Id[strValue.ToUpperInvariant()];
            return null;
        }

        public string GetValueById(int? nId)
        {
            if (nId == null)
                return "";

            if (m_Id2Value.ContainsKey((int)nId))
                return m_Id2Value[(int)nId];
            return "";
        }

        public Tm_DictionaryItem GetDictionaryItemById(int? nId)
        {
            if (nId == null)
                return new Tm_DictionaryItem();

            if (m_Id2Value.ContainsKey((int)nId))
                return new Tm_DictionaryItem((int)nId, m_Id2Value[(int)nId], string.Empty, false);

            return new Tm_DictionaryItem();
        }

        public List<string> GetValues()
        {
            return new List<string>(m_Value2Id.Keys);
        }

        public bool IsEmpty()
        {
            return m_Dictionary.Count == 0;
        }

        public int? GetIndexById(int? nId)
        {
            if (nId == null)
                return null;
            for (int i = 0; i < m_Dictionary.Count; i++)
            {
                if (nId.Value == m_Dictionary[i].nId)
                    return i;
            }
            return null;
        }

        /// <summary>
        /// Метод переставляет на первое место в словаре значение с переданным индексом 
        /// </summary>
        /// <param name="nIndexOfItem">Индекс значения, которое надо поставить на первое место в словаре</param>
        /// <returns>True - удачная перестановка. False - неудачная перестановка.</returns>
        public bool SetThisItemOnTheFirstPlace(int nIndexOfItem)
        {
            if (nIndexOfItem >= m_Dictionary.Count)
            {
                System.Diagnostics.Debug.Assert(false);
                return false;
            }
            else
            {
                Tm_DictionaryItem item = m_Dictionary[nIndexOfItem];
                List<Tm_DictionaryItem> newDictionary = new List<Tm_DictionaryItem>();
                newDictionary.Add(item);
                for (int i = 0; i < m_Dictionary.Count; i++)
                {
                    if (i != nIndexOfItem)
                        newDictionary.Add(m_Dictionary[i]);
                }
                m_Dictionary = newDictionary;
                return true;
            }
        }
    }
}
