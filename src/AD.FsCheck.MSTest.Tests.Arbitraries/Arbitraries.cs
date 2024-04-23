namespace AD.FsCheck.MSTest.Tests.Arbitraries;

public static class Arbitraries
{
    public static Arbitrary<From100To200> From100To200(IArbMap map) => Arb.From(
        Gen.Choose(100, 200).Select(value => new From100To200(value)),
        from100To200 => map.ArbFor<int>().Shrinker(from100To200.Value).Where(value => value >= 100 && value <= 200).Select(value => new From100To200(value)));

    public static IArbMap Merge(IArbMap arbMap) => arbMap
        .MergeArbFactory(From100To200);
}