   M S B A M L   `   `   `  ����D  @Comp_Club, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Comp_Club	Comp_Club  5          Comp_Club.reportsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Comp_Club     5        N� Title$  Отчеты��5	      .��5
      �    DarkGridStyle#��[  6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� -   5         ��Name$ MainTab��5      $��10q�6&   .@�5      �� $)��#Ежедневная выручка��6   .��5      � ���#06062a$��10q�6,   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dailyRevenueDataGrid��5         AutoGenerateColumns .     
IsReadOnly . 
�������$��16(�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Категория��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6a   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6D   �� *
Category+6a     5      $ Выручка��61   $ * 6^   	 6B   �� *	Revenue+6^   5      5      5      �� 5"      $(��"Запчасти на складе��6   .��5#      � ���#06062a$��10q�6,   .+�5$        -   5        $ repairPartsDataGrid��5$       .   . 
�������$��16(�5(       5)        5*      $ 
Товар��61   $ * 6^   	 6@   �� *	PartsName+6^     5+      $ Количество��61   $ * 6a   	 6E   �� *	Balance+6a   5-      5.      5/      �� 52      $%��Популярные блюда��6   .��53      � ���#06062a$��10q�6,   .+�54        -   5        $ popularDishesDataGrid��54       .   . 
�������$��16(�58       59        5:      $ 
Блюдо��61   $ * 6]   	 6@   �� *
DishName+6]     5;      $ Заказов��61   $ * 6a   	 6B   �� *
OrderCount+6a   5=      5>      5?      �� 5B      $��Посещения��6   .��5C      � ���#06062a$��10q�6,   .+�5D        -   5        $ guestStatsDataGrid��5D       .   . 
�������$��16(�5H       5I        5J      $ Период��61   $ * 6\   	 6A   �� *Period+6\     5K      $ Посещения��61   $ * 6_   	 6D   �� *Visits+6_   5M      5O      5P      5Q      �� 5S   
   -   5        
 ��Name$
 addBut��5S      $��1��6!   $��Добавить��6.     NeonButtonStyle#��[ 6A   $
��Left=�6   �� 5T   
   -   5        $
 remBut��5T      $��1��6!   $��2��6.   $��Удалить��6>   #��[ 6P   $��Right=�6�   5U      5V      