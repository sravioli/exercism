using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private readonly Dictionary<int, List<string>> _roster = new();

    public bool Add(string student, int grade)
    {
        if (Roster().Contains(student))
        {
            return false;
        }

        _roster.TryGetValue(grade, out var students);
        students ??= [];
        students.Add(student);
        students.Sort();
        _roster[grade] = students;
        return true;
    }

    public IEnumerable<string> Roster()
    {
        List<string> roster = [];
        roster.AddRange(_roster.Keys.OrderBy(x => x).SelectMany(k => _roster[k]));
        return roster;
    }

    public IEnumerable<string> Grade(int grade) =>
        _roster.TryGetValue(grade, out var students) ? students.ToArray() : [];
}
