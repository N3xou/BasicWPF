   M S B A M L   `   `   `  ����C  ?Projekt1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Projekt1Projekt1  5   	       Projekt1.Menu   5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Projekt1     5   	     � Title$
  Menu��5
   	   $	��450��6   $	��800��6#   $	��450��6/   $	��800��6?    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5         HeaderStyle �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property �� Value �� 
StartPoint �� EndPoint � Color	 � Offset��%  &	        �� 5   
   "  6$   .�5      ��  � ��$ 0,0,0,0q�6(   �� 5       � �� 5      �� 5      $	 0,0&�6*   $	 1,0&�6;   .��5      � $ #00D4FF��6'   $	 0Q�67   � 5      $ #2d2dcc��6'   $
	 0.26Q�67   � 5      $ #2d2dcc��6'   $
	 0.72Q�67   � 5      $ #00D4FF��6'   $	 1Q�67   5      5      �� 5       � ��$ Center=�6;   �� 5       � ��
 �����6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ Italic$�6*   5      5       .��5!      � .+�5"   
   &   System.Windows.Controls.DataGrid  -   5        $��MenuGrid��5"      
   AutoGenerateColumns
 .  $��25(�6W      CanUserSortColumns . 
����ح�   CanUserAddRows .  ��6#   �� .@�6�   >   Columns 5$      4  .System.Windows.Controls.DataGridTemplateColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 25* 6*      
IsReadOnly .    HeaderStyle# [  6H      Header 5&      �� 5'      -   5         ��Name$ 	TextImage��5'   1   $��Image��6$   61      CellTemplate 5)      �� 5*      .R�5+      �� ��6$   �� *	Pathtoimg+5,      5/      0  *System.Windows.Controls.DataGridTextColumn  50         FontSize$ 22Q�6%   $	 25* 6L   # [  6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+ 51      �� 52      -   5        $ TextName��52   0   $
��Name��6$   60      ElementStyle 54      �� 55      " ��6    .�56      ��  �@��TextAlignment$ Center=�6>   �� 57       � ��$ 30(�69   �� 58       � ��$ 40��67   59      5;        5<      $ 22Q�6%   $	 25* 6d   # [  6p    63   �� *Price+ �� StringFormat$ {0:C}�� 5=      �� 5>      -   5        $ 	TextPrice��5>   1   $��Price��6$   61    5@      �� 5A      " ��6    .�5B      ��  �@��TextAlignment$ Center=�6>   �� 5C       � ��$ 30(�69   �� 5D       � ��$ 40��67   5E      5G        5H      $ 22Q�6%   $	 25* 6N   # [  6Z    63   �� *Status+ 5I      �� 5J      -   5        $ 
TextStatus��5J   2   $��Status��6$   62    5L      �� 5M      " ��6    .�5N      ��  �@��TextAlignment$ Center=�6>   �� 5O       � ��$ 30(�69   �� 5P       � ��$ 40��67   5Q      5S        5T      $	 25* 6)    . # [  6G    5U      �� 5V      -   5        $ TextActions��5V   3   $��Actions��6$   63    5X      �� 5Y      .R�5Z      �� $��Stack��6@    �� Orientation$ Vertical=�6)   .+�5[   "   ��  ��Name$ ChangePriceButton��6)   -   5        $��Stretch=�5[   [   
������ $��0q�6�   ��5\   &   �� 5]   *   $��5q�61   
���  �� �� CornerRadius$ 30��6W   
��� ��� �� Padding$	 7,5q�6}   ._�5^   .   �� $��15(�6Z   $
��Bold"�6h   
�������$��Italic$�6�   ��68   �� *TextChangePrice+6�   5_   +   5a   #   �� 5b   "   $ SetSoldOutButton��6)   -   5        $��Stretch=�5b   V   
������ $��0q�6�   $��3q�6�   ��5c   &   �� 5d   *   $��5q�61   ���#ff1a00$ 15��6[   ���#fa9000$	 7,5q�6�   ._�5e   .   �� $ zTextSoldOut��6W   $��15(�6m   $
��Bold"�6{   
�������$��Italic$�6�   ��68   �� *TextSetStatus+6�   5f   +   5h   #   5i      5j      5l       5n      *  $System.Windows.Controls.DataGridCell�� 5o      %�   '        �� 5p      "  6:   .�5q      ��  � ��
 �   �67   �� 5r       � �� 67   Z� �� 5s       � �� 68   Z� 5t      5v      5y      �� 5{   
   -	   5        $��Return��5{      $��1��6   $��8q�6?   $��75��6J   $��75��6V   $��Bottom=�6a   $
��Left=�6|    K� ZIndex$ 1��6�   ��5|      �� 5~      $5��/C:\Users\Yami\Desktop\x\Projekt1\img\Return.png��6   $
��Fill=�6Q   5�      5�      5�      