   M S B A M L   `   `   `  ����D  @Comp_Club, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Comp_Club	Comp_Club  5          Comp_Club.VIPClientPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Comp_Club     5        N� Title$  VIPClientPage��5	      .��5      �    DarkGridStyle#��[  6    � RowDefinitions 5   
   �� 5      �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��Клиенты��6   
�������$��20(�66   $
��Bold"�6D   $��
10,25,0,10q�6V   $��3��6j   &   System.Windows.Controls.DataGrid  5   
   -   5        $��VIPClientDataGrid��5      $��18(�6,      AutoGenerateColumns .  $��10,70,10,23q�6V   $��3��6k      
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Имя��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6K   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *Name+6K     5      $ Телефон��6%   $ * 6P    66   �� *Phone+6P     5      $ 
Почта��6%   $ * 6N    64   �� *Email+6N     5      $ Скидка %��6%   $ * 6T    67   �� *
Discount+6T     5      $ Уровень VIP��6%   $ * 6X    6:   �� *	VIP_Level+6X   5!      �� 5#   
   -   5        	 ��Name$	 addBut��5#      $��1��6!   $%��Добавить клиента��6.     NeonButtonStyle#��[ 6I   6r   �� 5$   
   -   5        $	 remBut��5$      $��1��6!   $��2��6.   $#��Удалить клиента��6>   #��[ 6X   6�   5&      5'      