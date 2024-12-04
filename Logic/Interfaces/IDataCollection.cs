using Logic.Interfaces.Table_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IDataCollection
    {
        public IEducation Education { get; }
        public ICourse Course { get; }
        public ISpecs Specs { get; }
        public ISubj Subj { get; }
        public IUser User { get; }
        public INotes Notes { get; }
        public IAdminKeys AdminKeys { get; }
        public IInternshipGoal InternshipGoal { get; }
    }
}
