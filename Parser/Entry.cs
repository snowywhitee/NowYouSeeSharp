//using Microsoft.VisualStudio.Tools.Applications.Runtime;

namespace Parser
{
    public class Entry
    {
        //Fields
        private bool confidentialityBreach;
        private bool integrityViolation;
        private bool accessibilityViolation;

        //Properties
        public int Id { get; private set; }
        public string IdStr
        {
            get
            {
                if (Id >= 100)
                {
                    return $"УБИ.{Id}";
                }
                else if (Id < 100 && Id >= 10)
                {
                    return $"УБИ.0{Id}";
                }
                else
                {
                    return $"УБИ.00{Id}";
                }
            }
        }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Source { get; private set; }
        public string Target { get; private set; }
        public string ConfidentialityBreach
        {
            get
            {
                if (confidentialityBreach)
                {
                    return "да";
                }
                return "нет";
            }
            private set
            {
                if (value == "да" || value == "1")
                {
                    confidentialityBreach = true;
                }
                else
                {
                    confidentialityBreach = false;
                }
                
            }
        }
        public string IntegrityViolation
        {
            get
            {
                if (integrityViolation)
                {
                    return "да";
                }
                return "нет";
            }
            private set
            {
                if (value == "да" || value == "1")
                {
                    integrityViolation = true;
                }
                else
                {
                    integrityViolation = false;
                }
            }
        }
        public string AccessibilityViolation
        {
            get
            {
                if (accessibilityViolation)
                {
                    return "да";
                }
                return "нет";
            }
            private set
            {
                if (value == "да" || value == "1")
                {
                    accessibilityViolation = true;
                }
                else
                {
                    accessibilityViolation = false;
                }
            }
        }

        public Entry(Entry entry)
        {
            Id = entry.Id;
            Name = entry.Name;
            Description = entry.Description;
            Source = entry.Source;
            Target = entry.Target;
            ConfidentialityBreach = entry.ConfidentialityBreach;
            IntegrityViolation = entry.IntegrityViolation;
            AccessibilityViolation = entry.AccessibilityViolation;
        }
        public Entry(string[] row)
        {
            Id = int.Parse(row[0]);
            Name = row[1];
            Description = row[2];
            Source = row[3];
            Target = row[4];
            ConfidentialityBreach = row[5];
            IntegrityViolation = row[6];
            AccessibilityViolation = row[7];
        }
        public override string ToString()
        {
            return $"Наименование: {Name}\n" +
                    $"Описание: {Description}\n" +
                    $"Источник: {Source}\n" +
                    $"Объект: {Target}\n" +
                    $"Нарушение конфиденциальности: {ConfidentialityBreach}\n" +
                    $"Нарушение целостности: {IntegrityViolation}\n" +
                    $"Нарушение доступности: {AccessibilityViolation}";
        }

        //Operators
        public override bool Equals(object obj)
        {
            return obj is Entry entry &&
                   Id == entry.Id &&
                   Name == entry.Name &&
                   Description == entry.Description &&
                   Source == entry.Source &&
                   Target == entry.Target &&
                   ConfidentialityBreach == entry.ConfidentialityBreach &&
                   IntegrityViolation == entry.IntegrityViolation &&
                   AccessibilityViolation == entry.AccessibilityViolation;
        }
        public static bool operator ==(Entry a, Entry b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Entry a, Entry b)
        {
            return !(a == b);
        }
    }
}
