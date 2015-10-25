namespace LessonsSamples.Lesson8.Validation
{
	class AddressValidationRules : EntityValidationRulesRegistrator<Address>
	{
		protected override void RegisterTo(IValidationRulesSet<Address> rulesSet)
		{
			rulesSet
				.Required(a => a.Street)

				.DefineNewState(a => a.CountryID == (int) Country.RO)
					.Required(a => a.Number, ValidationMessages.AddressNumber)
					.Required(a => a.PostCode)
					.RegularExpression(a => a.PostCode, postCodeRegex)

				.DefineNewState(a => a.CountryID != (int) Country.RO)
					.Required(a => a.City)
			;
		}

		private string postCodeRegex;
	}
}
