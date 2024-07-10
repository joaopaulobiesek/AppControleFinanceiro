using AppControleFinanceiro.Repositories;
using CommunityToolkit.Mvvm.Messaging;

namespace AppControleFinanceiro.Views;

public partial class TransactionList : ContentPage
{
    private readonly ITransactionRepository _repository;
    public TransactionList(ITransactionRepository repository)
    {
        _repository = repository;
        InitializeComponent();
        Reload();
        WeakReferenceMessenger.Default.Register<string>(this, (e, msg) =>
        {
            Reload();
        });
    }

    private void Reload()
        => CollectionViewTransactions.ItemsSource = _repository.GetAll();

    private void OnButtonClicked_to_TransactionAdd(object sender, EventArgs args)
    {
        var transactionAdd = Handler.MauiContext.Services.GetService<TransactionAdd>();
        Navigation.PushModalAsync(transactionAdd);
    }

    private void OnButtonClicked_to_TransactionEdit(object sender, EventArgs args)
    {
        var transactionEdit = Handler.MauiContext.Services.GetService<TransactionEdit>();
        Navigation.PushModalAsync(transactionEdit);
    }
}