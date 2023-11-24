using Kiosk_UI;
using NUnit.Framework;
using System.Windows.Forms;
using System;

[TestFixture]
public class ARSTests
{
    private MainForm mainForm;

    [SetUp]
    public void SetUp()
    {
        mainForm = new MainForm();
    }

    [Test]
    public void TestExitScenario()
    {
        var keyEvent = new System.Windows.Forms.KeyEventArgs(Keys.NumPad9); // 수정된 부분
        mainForm.ARS(keyEvent);

        // 종료 시나리오에 대한 검증 로직 추가
        Assert.AreEqual(0, mainForm.key_flag);
        Assert.AreEqual(0, mainForm.key_flag2);
        Assert.AreEqual(0, mainForm.back_flag);
        // 추가 검증 로직 추가
    }

    [Test]
    public void TestDrinkSelectionScenario()
    {
        var keyEvent = new System.Windows.Forms.KeyEventArgs(Keys.NumPad0); // 수정된 부분
        mainForm.ARS(keyEvent);

        // 음료 선택 시나리오에 대한 검증 로직 추가
        Assert.AreEqual(1, mainForm.key_flag);
        Assert.AreEqual(0, mainForm.back_flag);
        // 추가 검증 로직 추가
    }

    // 다른 시나리오에 대한 테스트 메서드 추가

    private class KeyEventArgs : EventArgs
    {
        public Keys KeyCode { get; }

        public KeyEventArgs(Keys keyCode)
        {
            KeyCode = keyCode;
        }
    }
}

