using System;
using System.Collections.Generic;
using System.Linq;
using iQuarc.AppBoot;
using LessonsSamples.Lesson3.DataModel;

namespace LessonsSamples.ItCamp
{
    public interface IPolicyAdministrationService
    {
    }

    public interface IPolicyClassificationService
    {
    }

    [WcfService(typeof (IPolicyAdministrationService))]
    public class PolicyAdministrationService : IPolicyAdministrationService
    {
        private readonly IPolicyClassificationService classificationService;
        private readonly IRepository repository;

        public PolicyAdministrationService(IPolicyClassificationService classificationService, IRepository repository)
        {
            this.classificationService = classificationService;
            this.repository = repository;
        }

        public IEnumerable<Policy> GetPolicyImagesAffectedByMutation(Mutation mutation)
        {
            var policies = repository.GetEntities<PolicyImage>()
                                     .Where(image => image.MutationId == mutation.Id)
                                     .Select(image =>
                                         new Policy
                                         {
                                             Id = image.PolicyId,
                                             ValidAt = image.Mutation.Date
                                             //..
                                         })
                                     .ToList();
            // do other calculations / grouping on data
            return policies;
        }

        public void CalculateChanges(ChangeEvent change)
        {
            using (var uof = repository.CreateUnitOfWork())
            {
                var policies = repository.GetEntities<PolicyImage>()
                                         .Where(i => i.Status == ImageStatus.Calculating && i.EvendId == change.Id)
                                         .ToList();

                foreach (PolicyImage image in policies)
                {
                    image.Ammunt = GetAmmountFor(image, change);
                }

                uof.SaveChanges();
            }
        }

        private Mutation GetMutationFrom(ChangeEvent change)
        {
            throw new NotImplementedException();
        }


        private object GetAmmountFor(PolicyImage image, ChangeEvent change)
        {
            throw new NotImplementedException();
        }

        public enum ImageStatus
        {
            Calculating
        }

        public class ChangeEvent
        {
            public object Id { get; set; }
        }

        public class PolicyImage
        {
            public object MutationId { get; set; }
            public object PolicyId { get; set; }
            public Muatation Mutation { get; set; }
            public ImageStatus Status { get; set; }
            public object EvendId { get; set; }
            public object Ammunt { get; set; }
        }

        public class Muatation
        {
            public DateTime Date { get; set; }
        }

        public class Mutation
        {
            public object Id { get; set; }
        }

        public class Policy
        {
            public DateTime ValidAt { get; set; }
            public object Id { get; set; }
        }

        [Service(typeof (IPolicyClassificationService), Lifetime.Application)]
        private class PolicyClassificationService : IPolicyClassificationService
        {
            private readonly IRepository repository;

            public PolicyClassificationService(IRepository repository)
            {
                this.repository = repository;
            }

            //. . .
        }


        public class WcfServiceAttribute : Attribute
        {
            public WcfServiceAttribute(Type type)
            {
                throw new NotImplementedException();
            }
        }
    }
}