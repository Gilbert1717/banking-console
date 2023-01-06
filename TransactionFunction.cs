namespace s3665887_a1;

public class TransactionFunction
{
    public readonly double atmWithdraw = 0.05;
    public readonly double accountTransfer  = 0.1;
    public enum TransferType
    {
        D,//Credit (Deposit money) 
        W,//Debit (Withdraw money) 
        T,//Credit and Debit (Transferring money between accounts) 
        S//Debit (Service charge) 
    }

    public void transfer(TransferType type)
    {
        switch (type)
        {
            case TransferType.D:
                Console.WriteLine("Credit");
                break;
            case TransferType.W:
                Console.WriteLine("Debit");
                break;
            case TransferType.T:
                Console.WriteLine("Credit and Debit");
                break;
            case TransferType.S:
                Console.WriteLine("Debit");
                break;
        }
        
    }
    
    
}