# Exx-RandomData
Random Data PCL allows you to create instances of objects populated by random data. 
It is useful for developing UI. You can do it in your Xamarin projects.

#The usage
            var generator = new RandomDataGenerator<MyObject>();
            var myObject = generator.Generate();
            
            var generator = new RandomDataGenerator<MyObject>();
            var myObjects = generator.Generate(5);