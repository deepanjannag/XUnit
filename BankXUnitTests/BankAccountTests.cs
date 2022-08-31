using System;
using Xunit;
using XUnitDemo;

namespace BankXUnitTests
{
    public class BankAccountTests
    {
        [Fact]
        public void Adding_Funds_Updates_Balance()
        {
            //Arrange
            var account = new BankAccount(1000);

            //Act
            account.Add(100);

            //Assert
            Assert.Equal(1100, account.Balance);
        }

        [Fact]
        public void Withdraw_Funds_Updates_Balance()
        {
            //Arrange
            var account = new BankAccount(1000);

            //Act
            account.Withdraw(200);

            //Assert
            Assert.Equal(800, account.Balance);
        }

        [Fact]
        public void Transferring_Funds_Updates_Both_Accounts()
        {
            //Arrange
            var account = new BankAccount(1000);
            var otherAccount = new BankAccount(5000);

            //Act
            account.TransferFundsTo(otherAccount, 500);

            //Assert
            Assert.Equal(500, account.Balance);
            Assert.Equal(5500, otherAccount.Balance);
        }

        [Fact]
        public void Adding_NegativeFunds_Throws_Exception()
        {
            //Arrange
            var account = new BankAccount(1000);

            //Act + Assert            
            Assert.Throws<ArgumentOutOfRangeException>(()=> account.Add(-100));
        }

        [Fact]
        public void Withdraw_NegativeFunds_Throws_Exception()
        {
            //Arrange
            var account = new BankAccount(1000);            

            //Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(-100));
        }

        [Fact]
        public void Withdraw_MoreFundsThanBalance_Throws_Exception()
        {
            //Arrange
            var account = new BankAccount(1000);

            //Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(2000));
        }

        [Fact]
        public void Transferring_Funds_When_Other_Account_Null_Throws_Exception()
        {
            //Arrange
            var account = new BankAccount(1000);
            BankAccount otherAccount = null;

            //Act + Assert           
            Assert.Throws<ArgumentNullException>(() => account.TransferFundsTo(otherAccount, 100));
        }
    }
}