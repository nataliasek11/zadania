   M S B A M L   `   `   `  ����  Zadanie3    Zadanie3.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Media Library - New Style��5   	   $	��400��6+   $	��600��68   ���#2E3B4E � 	Resources 5      &   System.Windows.Controls.DataGrid �� 
TargetType �� Property �� Value��%�  '        '�� �     �� 5   
   "  6   .�5      ��  � �� �#2E3B4E6+   �� 5	       � ��
 �   �6+   �� 5
       �@ RowBackground �#3E4B5E6.   �� 5        �@ AlternatingRowBackground �#2E3B4E69   5      �� 5   
   " ��6   .�5      ��  � �� �#556B8E6+   �� 5       � ��
 �����6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 5q�6'   �� 5       � ��$
 10,5q�6(   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
     -   5          Name$ MediaDataGrid��5      $��0��6*   $��10q�67      AutoGenerateColumns$ False��6C      
IsReadOnly$
 True��6�   	   SelectionMode$	 Single=�6�   ��6_   �� *
MediaItems+
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Tytuł��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Tytul+6N     5      $ Autor/Reżyser��6%   $ 2* 6]    6<   �� *AutorRezyser+6]     5      $ Wydawca/Studio��6%   $ 2* 6_    6=   �� *WydawcaStudio+6_     5      $ Nośnik��6%   $ 1* 6P    65   �� *Nosnik+6P     5       $ Data Wydania��6%   $ 1* 6z    6;   �� *DataWydania+ �� StringFormat$ {0:dd/MM/yyyy}��6z   5"      �� 5#   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��10q�6X   .+�5$      �� -   5        $��Dodaj��5$      6%   �� 5%      -   5        $��Edytuj��5%      6&   �� 5&      -   5        $��Usuń��5&      6$   �� 5'      -   5        $��Importuj��5'      6(   �� 5(      -   5        $��	Eksportuj��5(      6)   5)      5*      5+      