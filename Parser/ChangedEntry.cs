using System;
using System.Collections.Generic;
//using Microsoft.VisualStudio.Tools.Applications.Runtime;


namespace Parser
{
    public class ChangedEntry : Entry
    {
        private string[] entryStatusStr = new string[] { "Новая запись", "Удалённая запись", "Измененная запись" };

        //Properties
        public EntryStatus Status { get; private set; }
        public string StatusStr { get => entryStatusStr[(int)Status]; }
        public Entry Parent { get; private set; }
        public string Before { get => GetChanges().Item1; }
        public string After { get => GetChanges().Item2; }

        //Methods
        public ChangedEntry(Entry entry, EntryStatus entryStatus, Entry parent) : base(entry)
        {
            Status = entryStatus;
            Parent = parent;
        }
        private (string, string) GetChanges()
        {
            if (Status == EntryStatus.Edited)
            {
                string before = "";
                string after = "";
                if (Parent.Name != Name)
                {
                    before += $"Наименование: {Parent.Name}\n";
                    after += $"Наименование: {Name}\n";
                }
                if (Parent.Description != Description)
                {
                    before += $"Описание: {Parent.Description}\n";
                    after += $"Описание: {Description}\n";
                }
                if (Parent.Source != Source)
                {
                    before += $"Источник: {Parent.Source}\n";
                    after += $"Источник: {Source}\n";
                }
                if (Parent.Target != Target)
                {
                    before += $"Источник: {Parent.Target}\n";
                    after += $"Источник: {Target}\n";
                }
                if (Parent.ConfidentialityBreach != ConfidentialityBreach)
                {
                    before += $"Источник: {Parent.ConfidentialityBreach}\n";
                    after += $"Источник: {ConfidentialityBreach}\n";
                }
                if (Parent.IntegrityViolation != IntegrityViolation)
                {
                    before += $"Источник: {Parent.IntegrityViolation}\n";
                    after += $"Источник: {IntegrityViolation}\n";
                }
                if (Parent.AccessibilityViolation != AccessibilityViolation)
                {
                    before += $"Источник: {Parent.AccessibilityViolation}\n";
                    after += $"Источник: {AccessibilityViolation}\n";
                }
                return (before, after);
            }
            else if (Status == EntryStatus.Removed)
            {
                return (Parent.ToString(), "-");
            }
            else
            {
                return ("-", ToString());
            }
        }

        //Operators
        public override bool Equals(object obj)
        {
            return obj is ChangedEntry entry &&
                   base.Equals(obj) &&
                   Id == entry.Id &&
                   Name == entry.Name &&
                   Description == entry.Description &&
                   Source == entry.Source &&
                   Target == entry.Target &&
                   ConfidentialityBreach == entry.ConfidentialityBreach &&
                   IntegrityViolation == entry.IntegrityViolation &&
                   AccessibilityViolation == entry.AccessibilityViolation &&
                   Status == entry.Status &&
                   EqualityComparer<Entry>.Default.Equals(Parent, entry.Parent) &&
                   Before == entry.Before &&
                   After == entry.After;
        }
        public static bool operator ==(ChangedEntry a, ChangedEntry b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(ChangedEntry a, ChangedEntry b)
        {
            return !(a == b);
        }
    }
    public enum EntryStatus
    {
        New = 0,
        Removed,
        Edited
    }
}
