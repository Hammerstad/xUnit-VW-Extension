namespace TestxUnit_VW
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Annotations;
    using Xunit;
    using Assert = Xunit.VW.Assert;

    public partial class AssertTest
    {
        public class PropertyChanged
        {
            // ReSharper disable once ClassWithVirtualMembersNeverInherited.Local
            private class MyNotifyPropertyChanged : INotifyPropertyChanged 
            {
                // ReSharper disable once MemberHidesStaticFromOuterClass
                public event PropertyChangedEventHandler PropertyChanged;

                public string Property1
                {
                    // ReSharper disable once ValueParameterNotUsed
                    set { PropertyChanged(this, new PropertyChangedEventArgs("Property1")); }
                }
                public int Property2
                {
                    // ReSharper disable once ValueParameterNotUsed
                    set { PropertyChanged(this, new PropertyChangedEventArgs("Property2")); }
                }

                [NotifyPropertyChangedInvocator]
                protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
                {
                    PropertyChangedEventHandler handler = PropertyChanged;
                    if (handler != null)
                    {
                        handler(this, new PropertyChangedEventArgs(propertyName));
                    }
                }
            }

            [Fact]
            [Trait("Type", "Real")]
            public void ActualPropertyChanged()
            {
                var propertyChanged = new MyNotifyPropertyChanged();
                Assert.PropertyChanged(propertyChanged, "Property1", () => propertyChanged.Property1 = "NewValue");
            }

            [Fact]
            [Trait("Type", "VW")]
            public void OtherPropertyChanged()
            {
                var propertyChanged = new MyNotifyPropertyChanged();
                Assert.PropertyChanged(propertyChanged, "Property1", () => propertyChanged.Property2 = 42);
            }
        }

        public class IsAssignableFrom
        {
            [Fact]
            [Trait("Type", "VW")]
            public void ObjectFromStringGenerics()
            {
                var @object = new Object();
                Assert.IsAssignableFrom<string>(@object);
            }

            [Fact]
            [Trait("Type", "VW")]
            public void ObjectFromString()
            {
                var @object = new Object();
                Assert.IsAssignableFrom(typeof(string), @object);
            }
            [Fact]
            [Trait("Type", "Real")]
            public void StringFromObjectGenerics()
            {
                const string String = "a string";
                Assert.IsAssignableFrom<object>(String);
            }

            [Fact]
            [Trait("Type", "Real")]
            public void StringFromObject()
            {
                const string String = "a string";
                Assert.IsAssignableFrom(typeof(object), String);
            }
        }
    }
}