   M S B A M L   `   `   `  ����C  ?Projekt1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Projekt1Projekt1  5   	       Projekt1.Details   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Projekt1     5   	     � Title$  Details��5   	   $	��450��6   $	��800��6&   $	��450��62   $	��800��6B    � WindowStartupLocation$ CenterScreen=�5	   	    � 	Resources 5
         HeaderStyle �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property �� Value �� 
StartPoint �� EndPoint � Color	 � Offset��%  &	        �� 5   
   "  6$   .�5      ��  � ��$ 0,0,0,0q�6(   �� 5       � �� 5      �� 5      $	 0,0&�6*   $	 1,0&�6;   .��5      � $ #00D4FF��6'   $	 0Q�67   � 5      $ #2d2dcc��6'   $
	 0.26Q�67   � 5      $ #2d2dcc��6'   $
	 0.72Q�67   � 5      $ #00D4FF��6'   $	 1Q�67   5      5      �� 5       � ��$ Center=�6;   �� 5       � ��
 �����6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ Italic$�6*   5      5      .��5      � 
 � RowDefinitions
 5   
   �� 5      $��2* �6   �� 5       $��8* �6    � ColumnDefinitions 5"   
   �� 5#      $	��50* �6   �� 5$      $	��50* �6   .+�5&   
   �� $��0��6   $��10q�6"    �� Orientation$ 
Horizontal=�6/   $��0��6H   .+�5'      �� -   5         ��Name$ TextON��5'   .   $��Order Number: ��6   $
��Bold"�6>   $��30(�6P   �� 5(      -   5        $ orderNum��5(   !   $��0��6   $
��Bold"�63   $��30(�6E   5)      �� 5*   
   $��0��6   $��10q�6"   $ 
Horizontal=�6/   $��1��6H   .+�5+      �� -   5        $ TextTP��5+   -   $��Total Price: ��6   $
��Bold"�6=   $��30(�6O   �� 5,      -   5        $ 
totalPrice��5,       $�� ��6   $
��Bold"�64   $��30(�6F   5-      &   System.Windows.Controls.DataGrid  5.   
   -   5          Name$ DetailsGrid��5.         AutoGenerateColumns .  $��25(�6D      CanUserSortColumns . 
����ح�$��1��6�   $��2��6�      Columns 5/      4  .System.Windows.Controls.DataGridTemplateColumn  50      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 25* 6*      
IsReadOnly .    HeaderStyle# [  6H      CellTemplate 51      �� 52      .R�53      �� ��6$   �� *	pathtoimg+54         Header 56      �� 57      -   5        $ 	TextImage��57   1   $��Image��6$   61   59      0  *System.Windows.Controls.DataGridTextColumn  5:      $	 25* 6>   # [  6J   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *name+ 5;      �� 5<      -   5        $ TextName��5<   0   $
��Name��6$   $
��Bold"�6B      ElementStyle 5>      �� 5?      " ��6    .�5@      ��  �@��TextAlignment$ Center=�6>   �� 5A       � ��$ 30(�69   �� 5B       � ��$ 40��67   5C      5E        5G      $	 12* 6@   # [  6L    6%   �� *amount+ 5H      �� 5I      -   5        $ 
TextAmount��5I   2   $��Amount��6$   62    5K      �� 5L      " ��6    .�5M      ��  �@��TextAlignment$ Center=�6>   �� 5N       � ��$ 30(�69   �� 5O       � ��$ 40��67   5P      5R        5S      $	 25* 6W   # [  6c    6%   �� *price+ �� StringFormat$ {0:C}�� 5T      �� 5U      -	   5        $ 	TextPrice��5U   1   $��Price��6$   61    5W      �� 5X      " ��6    .�5Y      ��  �@��TextAlignment$ Center=�6>   �� 5Z       � ��$ 30(�69   �� 5[       � ��$ 40��67   5\      5^       5`      *  $System.Windows.Controls.DataGridCell�� 5a      %�   '        �� 5b      "  6:   .�5c      ��  � ��
 �   �67   �� 5d       � �� 67   Z� �� 5e       � �� 68   Z� 5f      5g      5i      �� 5j   
   -
   5        $��Return��5j      $��1��6   $��8q�6B   $��75��6M   $��75��6Y   $��Bottom=�6d   $
��Left=�6    K� ZIndex$ 1��6�   ��5k      �� 5m      $5��/C:\Users\Yami\Desktop\x\Projekt1\img\Return.png��6   $
��Fill=�6Q   5o      5p      5q      