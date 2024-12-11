using Logic.Interfaces;
using Logic.Interfaces.Table_Interfaces;
using Logic.Models_Logic.Table_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models_Logic
{
    public class DataCollection : IDataCollection
    {
        private readonly IEducation education;
        private readonly ICourse course;
        private readonly ISpecs specs;
        private readonly ISubj subj;
        private readonly IUser user;
        private readonly IAdminKeys adminKeys;
        private readonly INotes notes;
        private readonly IInternshipGoal internshipGoal;
        private readonly IInternshipGoalCheck internshipGoalCheck;

        public DataCollection(DBcontext Context)
        {
            education = new EducationRepo(Context);
            course = new CourseRepo(Context);
            specs = new SpecsRepo(Context);
            subj = new SubjRepo(Context);
            user = new UserRepo(Context);
            adminKeys = new AdminKeysRepo(Context);
            notes = new NotesRepo(Context);
            internshipGoal = new InternshipGoalRepo(Context);
            internshipGoalCheck = new InternshipGoalCheckRepo(Context);
        }
        public IEducation Education
        {
            get { return education; }
        }
        public ICourse Course
        {
            get { return course; }
        }
        public ISpecs Specs
        {
            get { return specs; }
        }
        public ISubj Subj
        {
            get { return subj; }
        }
        public IUser User
        {
            get { return user; }
        }
        public IAdminKeys AdminKeys
        {
            get { return adminKeys; }
        }
        public INotes Notes
        {
            get { return notes; }
        }
        public IInternshipGoal InternshipGoal
        {
            get { return internshipGoal; }
        }
        public IInternshipGoalCheck InternshipGoalCheck
        {
            get { return internshipGoalCheck; }
        }
    }
}
