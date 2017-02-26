using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDb.DataAccess
{
    //TODO: modify the code generator to generate these entities to implement ITenantEntity
    public partial class Patient : ITenantEntity
    {
    }

    public partial class PatientFile : ITenantEntity
    {
    }

    public partial class PatientHistory : ITenantEntity
    {
    }
}
