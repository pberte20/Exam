namespace Exam
{
    using System.Collections.Generic;
    public interface IDataLoader<T>
    {
        List<T> LoadData(IEnumerable<string> lines);
    }
}