   M S B A M L   `   `   `  ����@  <My_BD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:My_BDMy_BD  5   	       My_BD.AdminLogirovanie   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:My_BD     5   	     � Title$=  7Просмотр логов: Администратор��5   	   $	��620��6/   $
��1350��6<   ���#FFDEAD � 
ResizeMode$ NoResize=�5	       � WindowStartupLocation$ CenterOwner=�6    � Icon$- 'H:\Новая папка\My_BD\icon.png��6<   .��5
      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DBLogirovanie��5         AutoGenerateColumns .     
IsReadOnly . $
��Left=�5      $
��1350��5      $	��450��5         	RowHeight$ 50Q�5         RowBackground �#e0ad52	   AlternatingRowBackground	 �#dcc7a3$��17(�5      $��Times New Roman)�5      
   Columns
 5   
   0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Код записи��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 276 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Код_записи+6f     5      $ Время входа��6%   $	 124 6Z    6:   �� *Время_входа+6h     5      $ 
Логин��6%   $	 165 6N    64   �� *
Логин+6\     5      $ Зашол или нет��6%   $	 300 6^    6<   �� *Зашол_или_нет+6l     5      $ Примечание��6%   $	 500 6X    69   �� *Примечание+6f   5      �� 5   
   -   5        ���#FFDAB9$��В меню��5   
   $��Center=�5   
   $��	0,518,0,0q�5    
   $	��Top=�5!   
    J� RenderTransformOrigin$ 2.957,25.152&�5"   
   $��42��5#   
   $	��264��5$   
   5%   
   �� 5&   
   $*��$Количество записей:��6   $
��Left=�6.   $��946,539,0,0q�6I   $	��Top=�6^   $��Times New Roman)�6v   $��17(�6�   �� 5'   
   -   5         ��Name$ RowCount��5'      $�� ��6"   $
��Left=�6-   $��1111,539,0,0q�6H   $	��Top=�6^   $ 0.145,0.145&�6v   $��Times New Roman)�6�   $��17(�6�   5(      5)      