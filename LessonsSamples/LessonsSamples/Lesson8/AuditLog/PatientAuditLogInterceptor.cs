using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iQuarc.DataAccess;
using iQuarc.AppBoot;

namespace LessonsSamples.Lesson8.AuditLog
{
    [Service(nameof(PatientAuditLogInterceptor), typeof(IEntityInterceptor<Patient>))]
    class PatientAuditLogInterceptor : EntityInterceptor<Patient>
    {
        private readonly IAuditLog auditLog;

        public PatientAuditLogInterceptor(IAuditLog auditLog)
        {
            this.auditLog = auditLog;
        }

        public void OnLoad(IEntityEntry<Patient> entry, IRepository repository)
        {
            User user = GetCurrentUser();
            Patient patient = entry.Entity;
            auditLog.Write(AuditType.Read, $"Patient data was read. Patient Name: {patient.Name}", user);
        }

        public void OnSave(IEntityEntry<Patient> entry, IUnitOfWork unitOfWork)
        {
            User user = GetCurrentUser();
            Patient patient = entry.Entity;

            if (entry.State == EntityEntryState.Added)
                auditLog.Write(AuditType.Added, $"Patient was added. Patient Name: {patient.Name}", user);
            else
                auditLog.Write(AuditType.Added, $"Patient was modified. Patient Name: {patient.Name}", user);
        }
        public void OnDelete(IEntityEntry<Patient> entry, IUnitOfWork unitOfWork)
        {
            User user = GetCurrentUser();
            Patient patient = entry.Entity;
            auditLog.Write(AuditType.Deleted, $"Patient was deleted. Patient Name: {patient.Name}", user);
        }

        private User GetCurrentUser()
        {
            throw new NotImplementedException();
        }
    }

    internal class User
    {
    }

    internal class Patient
    {
        public string Name { get; set; }
    }

    enum AuditType
    {
        Read,
        Added,
        Deleted
    }
}
