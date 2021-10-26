using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class CvBuilder
    {
        private CV _cv;
        public CvBuilder()
        {
            _cv = new CV();
            _cv.Skills = new List<string>();
            _cv.Projects = new List<Project>();
            _cv.Educations = new List<string>();
            _cv.References = new List<string>();
        }

        //Note:- every method we use method chaining feature,drop [void] type use [CvBuilder] class type name and
        // [return this;] with every class

        public CvBuilder AddName(string name)
        {
            _cv.Name = name;
            return this;
        }

        public CvBuilder AddImage(string image)
        {
            _cv.Image = image;
            return this;

        }

        public CvBuilder AddReferences(string references)
        {
            _cv.References.Add(references);
            return this;

        }

        public CvBuilder AddSkills(string skills)
        {
            _cv.Skills.Add(skills);
            return this;

        }

        public CvBuilder AddProjects(string projectName, DateTime startDate, DateTime endDate, List<string> skills)
        {
            _cv.Projects.Add(new Project {Name = projectName, StartDate = startDate, 
                EndDate = endDate, Skills = skills });
            return this;

        }

        public CV GetCV()
        {
            return _cv;
        }
    }

}
