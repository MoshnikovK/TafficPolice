   M S B A M L   `   `   `  ����@  <My_BD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:My_BDMy_BD  5   	       My_BD.UserForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:My_BD     5   	     � Title$C  =Просмотр нарушение: Пользователь��5      $	��620��6.   $
��1153��6;   ���#FFDEAD � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterOwner=�5   	    � Icon$- 'H:\Новая папка\My_BD\icon.png��5   	   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DGCars��5         AutoGenerateColumns .     
IsReadOnly . $
��Left=�5      $
��1153��5      $	��450��5         	RowHeight$ 50Q�5         RowBackground �#e0ad52	   AlternatingRowBackground	 �#dcc7a3$��17(�5      $��Times New Roman)�5      
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$% Номер автомобиля��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 180 6d   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *!Номер_автомобиля+6r     5      $F @Номер водительского удостоверения��6%   $	 280 6�    6P   �� *B@Номер_водительского_удостоверения+6�     5      $ 
Марка��6%   $	 100 6N    64   �� *
Марка+6\     5      $ Модель��6%   $	 100 6P    65   �� *Модель+6^     5      $ Цвет��6%   $	 100 6L    63   �� *
Цвет+6Z     5      $ Год выпуска��6%   $	 130 6Z    6:   �� *Год_выпуска+6h     5       $/ )Дата регистрации в ГАИ��6%   $	 130 6p    6E   �� *+)Дата_регистрации_в_ГАИ+6~     5!      $  Данные в архив��6%   $	 130 6`    6=   �� *Данные_в_архив+6n   5#      �� 5$   
   -   5        ���#FFDAB9$��В меню��5%      $��Center=�5&      $��	0,518,0,0q�5'      $	��Top=�5(       J� RenderTransformOrigin$ 2.957,25.152&�5)      $��42��5*      $	��264��5+      5,      �� 5-   
   $*��$Количество записей:��6   $
��Left=�6.   $��861,542,0,0q�6I   $	��Top=�6^   $��Times New Roman)�6v   $��17(�6�   �� 5.   
   -   5         ��Name$ RowCount��5.      $�� ��6"   $
��Left=�6-   $��1021,542,0,0q�6H   $	��Top=�6^   $ 0.145,0.145&�6v   $��Times New Roman)�6�   $��17(�6�   5/      50      