   M S B A M L   `   `   `  ����I  ECrematorium.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Crematorium.UI.PagesCrematorium.UI.Pages  5      *    $Crematorium.UI.Pages.HallServicePage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Crematorium.UI.Pages     5      
������   � 	Resources  5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $; 5pack://application:,,,/Resourse/Styles/BtnStyles.xaml?�6%   �� 5      $< 6pack://application:,,,/Resourse/Styles/TextStyles.xaml?�6%   �� 5      $@ :pack://application:,,,/Resourse/Styles/ElementsStyles.xaml?�6%   �� 5      $@ :pack://application:,,,/Resourse/Styles/DataGridStyles.xaml?�6%   �� 5      $@ :pack://application:,,,/Resourse/Styles/ComboBoxStyles.xaml?�6%   %    5      .��5      ��  �� CornerRadius$ 10��6   ���	#FFF8D0D0._�5   
   �  � ColumnDefinitions 5      �� 5      $��20 �6#   �� 5      �� 5      �� 5      �� 5      �� 5      $��20 �6#    � RowDefinitions 5!      �� 5"      $��50 �6    �� 5#      $��20 �6    �� 5$      $��30 �6    �� 5%      $��20 �6    �� 5&      �� 5'      �� 5(      �� 5)      $��20 �6    .+�5-      �� $��0��6   $��6��5.      $��Hall Service��5/      $��Center=�50      $��32(�51      �� 54      $��2��6   $��1��55      $��Right=�56      $��Name of hall��57      $��0, 0, 10, 0q�58      �� 59      $��2��6   $��2��5:       �� TextAlignment$ Center=�5;      $	��200��5<      $��25��5=      ��5>      �� *InputFindName+�� 5?      $��3��6   $��2��5@      $��80��5A      $
��Left=�5B      ���	#FFF53657$��10, 0, 0, 0q�5D         BaseBtnStyle#��[  5F      ��5E      �� *FindHallsCommand+.��5G      �� $
��Find��6   5H      &   System.Windows.Controls.DataGrid  5K      -   5          Name$ UsersDataGrid��5M      $��4��5K      $��3��6$   $��1��5L      $��3��6'      
IsReadOnly$
 True��5N        BaseDataGrid#��[ 5O      ��5P      �� *Halls+	 �� SelectedItem	 5Q      �� 
 �� Path$
 SelectedHall�   Columns 5R      0  *System.Windows.Controls.DataGridTextColumn  5S      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 5T   )   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5U   )   �� $
 Id�  5V      $
 Name��6)   $	 180 5W   )    5X   )   �� $

 Name�  5Y      $ Capacity��6)   $ * 5Z   )    63   �� $
 Capacity�  5[      $ Price��6)   $ * 5\   )    63   �� $
 Price�4  .System.Windows.Controls.DataGridTemplateColumn  5]      $ 
Free dates��6-   $	 190 6A      CellTemplate 5^      �� 5_      .R�5`   "   �� $	��180��6,   $��30��68   $
��Left=�5a   ,   ���	#FFF53657 �� DisplayMemberPath$
 Data��5d   ,   ��5c   ,   �� $
 	FreeDates�5d   ,   5e      5g      5i      �� 5l      $��4��6   $��4��5m      $��90��5n      ���	#FFF53657#��[  5q      ��5p      �� $
 AddHallCommand�.��5r      �� $	��Add��6   $��
0, 0, 0, 0q�5s      5t      �� 5u      $��4��6   $��5��5v      $��90��5w      ���	#FFF53657#��[  5z      ��5y      �� $
 UpdateHallCommand�.��5{      �� $
��Edit��6   $��
0, 0, 0, 0q�5|      5}      �� 5~      $��4��6   $��6��5      $��90��5�      ���	#FFF53657#��[  5�      ��5�      �� $
 DeleteHallCommand�.��5�      �� $��Remove��6   $��
0, 0, 0, 0q�5�      5�       � 5�      -   5          �Name$ 	FrameUrns��5�      $��0��5�      $��6��6$   $��0��5�      $��8��6!   5�      5�      5�      