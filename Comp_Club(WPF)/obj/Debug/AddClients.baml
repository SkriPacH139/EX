   M S B A M L   `   `   `  ����D  @Comp_Club, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Comp_Club	Comp_Club  5   	       Comp_Club.AddClients   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Comp_Club     5   	     � Title$%  Добавить клиента��5   	   $	��350��6"   $	��450��6/    � WindowStartupLocation$ CenterOwner=�6;   $��20(�6_   .��5	      �    DarkGridStyle#��[  6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $	��140 �6   �� 5      .+�5   
   �� $��Имя:��6   $��0��6    $��0��6-     LabelTextStyle#��[ 6=   �� 5   
   -   5         ��Name$ NameTextBox��5      $��0��6'   $��1��64   $��5q�6D   �� 5   
   $��Телефон:��6   $��1��6$   $��0��61   #��[ 6A   �� 5   
   -   5        $ PhoneTextBox��5      $��1��6(   $��1��65   $��5q�6E   �� 5   
   $��Почта:��6   $��2��6"   $��0��6/   #��[ 6?   �� 5   
   -   5        $ EmailTextBox��5      $��2��6(   $��1��65   $��5q�6E   �� 5    
   $��Скидка:��6   $��3��6#   $��0��60   #��[ 6@   �� 5!   
   -   5        $ DiscountTextBox��5!      $��3��6+   $��1��68   $��5q�6H   $��0��6S   �� 5#   
   $��Уровень VIP:��6   $��4��6(   $��0��65   #��[ 6E   �� 5$   
   -   5        $ VIPLevelTextBox��5$      $��4��6+   $��1��68   $��5q�6H   �� 5&   
   $��5��6   $��2��6"    �� Orientation$ 
Horizontal=�66   $��Right=�6O   .+�5'      �� -   5         ��Name$ 	AddButton��5'      $��Добавить��6(     NeonButtonStyle#��[ 6;   6d   �� 5(      -   5        $ CancelButton��5(      $��Отмена��6+   #��[ 6<   6e   5)      5*      5+      