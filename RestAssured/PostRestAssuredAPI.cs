namespace RestAssured
{
    public class PostRestAssuredAPI
    {

        [Test]
        public void Test1()
        {
            var response = Given().When().Get("http://api.zippopotam.us/us/90210");
            var country = response.Extract().Body("$.['country abbreviation']");
            Assert.That(country, Is.EqualTo("US"));
        }

        [Test]
        public void Test2()
        {
            var response = Given().When().Get("http://api.zippopotam.us/us/90210");
            var country = response.Extract().Body("$.places[0].state");
            Assert.That(country, Is.EqualTo("California"));
        }


        [Test]
        public void Test3()
        {
            var response = Given().When().Get("http://api.zippopotam.us/us/90210");
            var state = response.Extract().Body("$.places[?(@.state=='California')].['state abbreviation']");
            Assert.That(state, Is.EqualTo("CA"));
        }
    }
}