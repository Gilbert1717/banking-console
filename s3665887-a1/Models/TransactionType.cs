namespace s3665887_a1.Models;

public enum TransactionType
{
    D, //Credit (Deposit money) 
    W, //Debit (Withdraw money) 
    T, //Credit and Debit (Transferring money between accounts) 
    S //Debit (Service charge) 
}