using System.Collections;
    [SerializeField] private UILabel purchaseRestoreNotUILabel = null;
    [SerializeField] private UILabel trans = null;
        storeKitGUIManager.NotPurchase += NotPurchase;
        storeKitGUIManager.NotPurchase -= NotPurchase;
    {
        trans.text = storeKitGUIManager.Transact;
    }
        purchaseRestoreSucessfullUILabel.enabled = false;
        purchaseRestoreNotUILabel.enabled = false;
    }

    private void NotPurchase()
    {
        ShowMessageWindow(purchaseRestoreNotUILabel);
    }