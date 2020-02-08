using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples01
{
    delegate bool FindStudent(Student std);

    class StudentExtension
    {
        public static Student[] where(Student[] stdArray, FindStudent del)
        {
            int i = 0;
            Student[] result = new Student[10];

            foreach (Student std in stdArray)
            {
                if (del(std))
                {
                    result[i++] = std;
                }
            }
            return result;
        }
    }
}
