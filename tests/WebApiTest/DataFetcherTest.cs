using System.Diagnostics;
using WebApi;
using WebApi.Entities;


namespace WebApiTest;

public class DataFetcherTest
{
    [Test]
    public void FetchProposition_Runs()
    {
        DataFetcher.FetchPropositions();
        Assert.Pass();
    }

    [Test]
    public void FetchProposition_ReturnsListOfPropositions()
    {
        List<Proposition> list = DataFetcher.FetchPropositions();
        var first = list.First();
        Assert.Multiple(() =>
        {
            Assert.That(first.Id, Is.EqualTo(new Guid("8a54dd08-5b50-484f-be58-c4a26142827a")));
            Assert.That(first.Text, Is.EqualTo("I suggest to make an app that makes democratic group decisions easier."));
        });
    }

    [Test]
    public void FetchOpinion_Runs()
    {
        DataFetcher.FetchOpinions();
        Assert.Pass();
    }

    //[Ignore("ignored")]
    [Test]
    public void FetchOpinion_ReturnsListOfOpinions()
    {
        List<Opinion> list = DataFetcher.FetchOpinions();
        var first = list.First();
        Assert.Multiple(() =>
        {
            Assert.That(first.Id, Is.EqualTo(new Guid("55d6beb9-c32c-470e-bfbf-31532237b1da")));
            Assert.That(first.Type, Is.EqualTo(OpinionType.HugeFan));
            Assert.That(first.Text, Is.EqualTo("Good idea!"));
            Assert.That(first.PropositionId, Is.EqualTo(new Guid("8a54dd08-5b50-484f-be58-c4a26142827a")));
        });
    }
}