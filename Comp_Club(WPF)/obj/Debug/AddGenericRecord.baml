   M S B A M L   `   `   `  ����D  @Comp_Club, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Comp_Club	Comp_Club  5   	        Comp_Club.AddGenericRecord   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Comp_Club     5   	     � Title$#  Добавить запись��5   
   $	��250��5	   	   $	��450��6    � WindowStartupLocation$ CenterOwner=�5
   	   $��18(�5   	   .��5      �    DarkGridStyle#��[  6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $	��195 �6   �� 5      .+�5   
   �� -   5         ��Name$ Label1��5      $��Поле 1:��6$   $��0��63   $��0��6@     LabelTextStyle#��[ 6P   �� 5   
   -   5         ��Name$ Field1TextBox��5      $��0��6)   $��1��66   $��5q�6F   �� 5   
   -   5        $ Label2��5      $��Поле 2:��6$   $��1��63   $��0��6@   #��[ 6P   �� 5   
   -   5        $ Field2TextBox��5      $��1��6)   $��1��66   $��5q�6F   �� 5   
   $��2��6   $��2��6"    �� Orientation$ 
Horizontal=�66   $��Right=�6O   .+�5      �� -   5        $��Добавить��5        NeonButtonStyle#��[ 6(   6Q   �� 5      -   5        $��Отмена��5      #��[ 6&   6O   5       5!      5"      