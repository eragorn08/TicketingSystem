   M S B A M L   `   `   `  ����K  GTicketing System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Ticketing_SystemTicketing_System  5   	   &     Ticketing_System.DataGrid_Assign   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Ticketing_System     5   	     � Title$  Assign a Ticket��5   	   $	��450��6!   $	��420��6.   .��5	      � .+�5
   
   �� .@�5      �� $��Pending��6   .��5      � ���	#FFE5E5E5 � ColumnDefinitions 5      �� 5      $	��29* �6+   �� 5      $
��109* �6+   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dgAssign��5      $��28,60,28,138q�5         AutoGenerateColumns .     CanUserResizeRows .  $y�Visible=�5         HeadersVisibility$	 All=�5         SelectionUnit$ FullRow=�5         SelectionMode$ Extended=�5      $��11(�5      $��2��5   F   ��5      ��  �� Path$ loaddatabinding�	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 	Ticket ID��6T      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� $ 	ticket_id�6g     5       $
 Customer Name��6T    .  61   �� $ 	cust_name�6k     5!      $
 Customer Email��6U    .  61   �� $ 
cust_email�6m     5"      $
 Problem Title��6U    .  61   �� $ 
prob_title�6l     5#      $
 Status��6O    .  61   �� $
 stat�6_     5$      $
 Date Created��6S    .  61   �� $ datetime�6i   5&      �� 5'      $��Assign an Unsolved Ticket��6   $
��Left=�6@   $��	80,18,0,0q�6[   $	��Top=�6n   $��20(�6�   $
��Bold"�6�   $��2��6�   �� 5(      -   5         ��Name$ btnShow_Unsolved��5(      $��1��67   $��	Show Data��6G   $
��Left=�6[   $��
77,298,0,0q�6v   $	��Top=�6�   $��45��6�   $��86��6�   $��15(�6�   $
��Bold"�6�   6�   5)      5*      �� 5+      $��Solved��6   .��5,      � ���	#FFE5E5E5 5-      �� 5.      $	��37* �6+   �� 5/      $
��377* �6+   .+�51        -   5        $ 
dgReAssign��52      $��28,60,28,130q�54       .   .  $y�Visible=�58      $	 All=�59      $ FullRow=�5:      $ Extended=�5;      $��11(�5<      $��2��5=   H   ��56      �� $ loaddatabinding�	 5>        5?      $
 	Ticket ID��6T    .  61   �� $ 	ticket_id�6g     5@      $
 Customer Name��6T    .  61   �� $ 	cust_name�6k     5A      $
 Customer Email��6U    .  61   �� $ 
cust_email�6m     5B      $
 Problem Title��6U    .  61   �� $ 
prob_title�6l     5C      $
 Status��6O    .  61   �� $
 stat�6_     5D      $
 Date Created��6S    .  61   �� $ datetime�6i     5E      $
 	Solved By��6R    .  61   �� $ solu_by�6e     5F      $
 	Solved on��6T    .  61   �� $ 	solved_on�6g   5H      �� 5I      $��Re-Assign a Solved Ticket��6   $
��Left=�6@   $��	45,18,0,0q�6[   $	��Top=�6n   $��20(�6�   $
��Bold"�6�   $��1��6�   �� 5J      -   5        $ btnShow_ReAssign��5J      $��1��67   $��	Show Data��6G   $
��Left=�6[   $��127,298,0,0q�6v   $	��Top=�6�   $��45��6�   $��86��6�   $��15(�6�   $
��Bold"�6�   6�   5K      5L      5M      5N      5O      