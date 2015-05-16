namespace LessonsSamples.Lesson7.CohesionCoupling
{
	public interface IExportDataProvider_4
	{
		CustomerInfo GetCustomerInfo(string name);
		Coordinates GetCoordinates(string city, string street, string number);
	}
}