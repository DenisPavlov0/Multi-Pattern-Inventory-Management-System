# Multi-Pattern Inventory Management System

## Описание проекта
Этот проект представляет собой систему инвентаря, использующую несколько популярных паттернов проектирования. В реализации используются паттерны:
- **Observer**
- **Factory**
- **Strategy**
- **Singleton**
- **Command**

### Цель
Целью данного проекта является создание системы инвентаря, в которой реализованы различные паттерны проектирования для управления предметами и их взаимодействием. Проект демонстрирует использование паттернов для улучшения гибкости, масштабируемости и поддерживаемости системы.

## Паттерны проектирования, использованные в системе

### 1. **Observer**
- **Роль**: UI подписывается на изменения инвентаря и автоматически обновляется при изменениях.
- **Описание**: Когда инвентарь изменяется (например, добавляется новый предмет), все подписчики получают уведомление для обновления отображения.

### 2. **Factory**
- **Роль**: Управляет созданием предметов разного типа (например, оружие, кольца, еда).
- **Описание**: В зависимости от типа предмета создаются соответствующие объекты с нужными характеристиками.

### 3. **Strategy**
- **Роль**: Разные алгоритмы сортировки (по имени, категории и т.д.).
- **Описание**: Система поддерживает несколько стратегий сортировки инвентаря, позволяя пользователю выбирать наиболее подходящий способ отображения предметов.

### 4. **Singleton**
- **Роль**: Глобальный менеджер инвентаря, доступный из любого места.
- **Описание**: Обеспечивает, что в системе существует только один экземпляр инвентаря, который доступен во всей программе.

### 5. **Command**
- **Роль**: История действий с возможностью отмены/повтора.
- **Описание**: Все действия пользователя (добавление, удаление предметов и т.д.) записываются, что позволяет отменять и повторять их в любой момент.

### 6. **Decorator** (не реализован)
- **Роль**: Расширение функционала предметов (например, добавление эффектов к оружию, таких как огонь, яд и т.д.).
- **Описание**: Этот паттерн был запланирован для добавления эффектов к предметам, но на данный момент не реализован в проекте.

