using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klemm.One.App.Model
{
    public class Skill
    {
        public static IEnumerable<Skill> GetSkills()
        {
            return new[]
            {
                new Skill()
                {
                    Name = "C#",
                    SkillLevel = SkillLevel.Proficient,
                    Description = @"Describing C# als my 'main' language fits the best.
                    While I was writing small and handy applications to optimize my workflow I discovered some nice technologies.
                    This includes patterns like MVVM and MVC but also TDD and unit testing in general.",
                    Image = "csharp.png"
                },
                new Skill
                {
                    Name =  "Angular 6",
                    SkillLevel =  SkillLevel.Proficient,
                    Description = "Starting with web development I discovered Angular 2 and loved it. With the help of it I created several responsive websites. And this website too.",
                    Image = "angular.svg"
                },
                new Skill
                {
                    Name = "Java",
                    SkillLevel =  SkillLevel.Familiar,
                    Description = "Java was my first OOP language taught in school. Since I discovered C# I switched away from it.",
                    Image = "java.png"
                },
                new Skill
                {
                    Name = "C++",
                    SkillLevel =  SkillLevel.Basic,
                    Description = @"While studying we used C++ and C to do the first steps in programming.
                    My experience includes basics like I / O, pointer, fundamentals of memory management and simple operations.",
                    Image = "cplusplus.svg"
                }
            };
        }

        public string Name { get; set; }
        public SkillLevel SkillLevel { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
