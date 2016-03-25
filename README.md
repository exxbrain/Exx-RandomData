# Exx-RandomData
Random Data PCL allows you to create instances of objects populated by random data. 
It is useful for developing UI. You can do it in your Xamarin projects.

#Usage
            var generator = new RandomDataGenerator<MyObject>();

            //generate one MyObject instance
            var myObject = generator.Generate();

            //Id property will have default value
            generator.Ignore(o => o.Id);

            //generate enumerable
            var myObjects = generator.Generate(5);