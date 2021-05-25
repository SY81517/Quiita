using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTTarget;

namespace UnitTestProject
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// https://qiita.com/gushwell/items/91436bd1871586f6e663
    /// </remarks>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// 親クラスからPrivate フィールドを取得
        /// </summary>
        /// <remarks>
        /// Type.GetField
        ///   https://docs.microsoft.com/ja-jp/dotnet/api/system.type.getfield?view=net-5.0
        /// BindingFlag
        ///   https://docs.microsoft.com/ja-jp/dotnet/api/system.reflection.bindingflags?view=net-5.0
        /// FieldInfo.GetValue
        ///   https://docs.microsoft.com/ja-jp/dotnet/api/system.reflection.fieldinfo.getvalue?view=net-5.0
        /// </remarks>
        [TestMethod]
        public void TestParent_GetPrivateField()
        {
            var privateSample= new Parent();
            //　オブジェクトから型を取得する
            //  BindingFlagでprivateを指定する
            var type = privateSample.GetType();
            var field = type.GetField(name: "_fieldPI",
                bindingAttr: BindingFlags.NonPublic |
                             BindingFlags.Instance);
            Assert.IsNotNull(field);
            // フィールドを取得する
            Assert.AreEqual(expected:3.14, actual:field.GetValue(privateSample));
        }

        /// <summary>
        /// 親クラスからPrivate フィールドを取得
        /// </summary>
        /// <remarks>
        /// FieldInfo.SetValue
        ///   https://docs.microsoft.com/ja-jp/dotnet/api/system.reflection.fieldinfo.setvalue?view=net-5.0
        /// </remarks>
        [TestMethod]
        public void TestParent_SetPrivateField()
        {
            var privateSample = new Parent();
            var type = privateSample.GetType();
            var field = type.GetField(name: "_fieldPI",
                bindingAttr: BindingFlags.NonPublic |
                             BindingFlags.Instance);
            Assert.IsNotNull(field);
            //値を設定したいオブジェクトと期待値を指定する。
            field.SetValue(obj:privateSample, value:3.1415);
            Assert.AreEqual(expected: 3.1415, actual: field.GetValue(privateSample));
        }

        /// <summary>
        /// 親クラスに定義したPrivate フィールドを取得
        /// </summary>
        /// <remarks>
        ///　Reflecting a private field from a base class
        /// 　　https://stackoverflow.com/questions/6961781/reflecting-a-private-field-from-a-base-class
        /// </remarks>
        [TestMethod]
        public void TestChild_GetParentPrivateField()
        {
            var privateSample = new Child();
            var type = privateSample.GetType().BaseType;
            Assert.IsNotNull(type);
            var field = type.GetField(name: "_fieldPI",
                bindingAttr: BindingFlags.NonPublic |
                             BindingFlags.Instance);
            Assert.IsNotNull(field);
            // フィールドを取得する
            Assert.AreEqual(expected: 3.14, actual: field.GetValue(privateSample));
        }

        /// <summary>
        /// 親クラスに定義したPrivate フィールドを取得
        /// </summary>
        [TestMethod]
        public void TestParent_SetParentPrivateField()
        {
            var privateSample = new Child();
            var type = privateSample.GetType().BaseType;
            Assert.IsNotNull(type);
            var field = type.GetField(name: "_fieldPI",
                bindingAttr: BindingFlags.NonPublic |
                             BindingFlags.Instance);
            Assert.IsNotNull(field);
            //値を設定したいオブジェクトと期待値を指定する。
            field.SetValue(obj: privateSample, value: 3.1415);
            Assert.AreEqual(expected: 3.1415, actual: field.GetValue(privateSample));
        }

    }
}
