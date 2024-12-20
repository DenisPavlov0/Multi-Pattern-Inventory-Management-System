    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UI;
    using Random = UnityEngine.Random;

    public class InventoryTester : MonoBehaviour
    {
        [SerializeField] private ItemData[] swords; 
        [SerializeField] private ItemData[] rings;
        [SerializeField] private ItemData[] eats;

        [SerializeField] private Button sortByName;
        [SerializeField] private Button sortByCategory;
        [SerializeField] private Button sortByNameLength;
        [SerializeField] private Button undoButton;
        
        [SerializeField] private Button addSword;
        [SerializeField] private Button addEat;
        [SerializeField] private Button addRing;
        [SerializeField] private Button removeLast;
        

        private ItemFactory _itemFactory;
        private CommandManager _commandManager;

        private void Start()
        {
            _itemFactory = new ItemFactory();
            _commandManager = new CommandManager();

            sortByName.onClick.AddListener(SortByName);
            sortByCategory.onClick.AddListener(SortByCategory);
            sortByNameLength.onClick.AddListener(SortByNameLength);
            undoButton.onClick.AddListener(UndoLastAction);
            removeLast.onClick.AddListener(RemoveLastItem);
            
            addSword.onClick.AddListener(() => AddItem(swords));
            addEat.onClick.AddListener(() => AddItem(eats));
            addRing.onClick.AddListener(() => AddItem(rings));
        }
        

        private void AddItem(ItemData[] item)
        {
            ExecuteAddItemCommand(GetRandomItem(item));
        }

        private void RemoveLastItem()
        {
            ExecuteRemoveItemCommand();
        }
        private void ExecuteAddItemCommand(ItemData itemData)
        {
            if (InventoryManager.Instance.GetRemainingSpace() <= 0)
            {
                Debug.Log("Inventory is full! Cannot add new items.");
                return;
            }

            var newItem = _itemFactory.CreateItem(itemData);
            var addCommand = new AddItemCommand(InventoryManager.Instance, newItem);
            _commandManager.ExecuteCommand(addCommand);
        }

        private void ExecuteRemoveItemCommand()
        {
            var itemList = InventoryManager.Instance.GetItems();
            if (itemList.Count == 0)
            {
                Debug.LogWarning("Inventory is empty. Cannot remove item.");
                return;
            }

            var lastItem = itemList.Last();
            var removeCommand = new RemoveItemCommand(InventoryManager.Instance, lastItem);
            _commandManager.ExecuteCommand(removeCommand);
        }

        private void SortByName()
        {
            TestSorting(new SortByName());
        }

        private void SortByCategory()
        {
            TestSorting(new SortByCategory());
        }

        private void SortByNameLength()
        {
            TestSorting(new SortByNameLength());
        }

        private void UndoLastAction()
        {
            _commandManager.UndoLastCommand();
        }

        private ItemData GetRandomItem(ItemData[] itemArray)
        {
            int randomIndex = Random.Range(0, itemArray.Length);
            return itemArray[randomIndex];
        }

        private void TestSorting(ISortStrategy sortStrategy)
        {
            List<Item> sortedItems = sortStrategy.Sort(InventoryManager.Instance.GetItems());
            InventoryManager.Instance.ReplaceItems(sortedItems);
        }

        private void OnDestroy()
        {
            sortByName.onClick.RemoveListener(SortByName);
            sortByCategory.onClick.RemoveListener(SortByCategory);
            sortByNameLength.onClick.RemoveListener(SortByNameLength);
            undoButton.onClick.RemoveListener(UndoLastAction);
            removeLast.onClick.RemoveListener(RemoveLastItem);
            
            addSword.onClick.RemoveListener(() => AddItem(swords));
            addEat.onClick.RemoveListener(() => AddItem(eats));
            addRing.onClick.RemoveListener(() => AddItem(rings));
        }
    }
