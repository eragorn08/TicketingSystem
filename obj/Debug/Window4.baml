   M S B A M L   `   `   `  ����K  GTicketing System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Ticketing_SystemTicketing_System  5   	       Ticketing_System.Window4   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Ticketing_System     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ Administrator Service��5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   $	��800��5   	   $
��1200��6   .��5      � .+�5   
   �� -   5        .@�5      �� $��SLA Compliance��6   $��20(�6.   .��5      � ���	#FFE5E5E5 � ColumnDefinitions 5      �� 5      $
��157* �6+   �� 5      $
��208* �6+   �� 5      $
��429* �6+   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dgSLA��5      $��28,97,28,207q�5         AutoGenerateColumns .     CanUserResizeRows .  $��3��5      $y�Visible=�5         HeadersVisibility$	 All=�5         SelectionUnit$ FullRow=�5       	   SelectionMode$	 Extended=�5!      $��29.25(�5"      ��5      �� 
 �� Path$
 loaddatabinding�   Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Ticket ID��6T      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� $
 	ticket_id�6g     5&      $ Customer Email��6U    .  61   �� $
 
cust_email�6m     5'      $ Problem Title��6U    .  61   �� $
 
prob_title�6l     5(      $ Assigned User��6S    .  61   �� $
 ass_user�6j     5)      $ Solution��6S    .  61   �� $
 solution�6e     5*      $ 	Solved By��6R    .  61   �� $
 solu_by�6e     5+      $ Status��6O    .  61   �� $

 stat�6_     5,      $
 Date��6S    .  61   �� $
 datetime�6a   5.      �� 5/      -   5         ��Name$ lblSLA��50      $��SLA COMPLIANCE��51      $
��Left=�52      $��
184,10,0,0q�53      $	��Top=�54      $	��353��55      $
��Bold"�56      $��40(�57      $��2��6'   $��1��6;   59      5:      �� 5;      $��Number of Tickets��6   $��20(�61   .��5<      � ���	#FFE5E5E5 5=      �� 5>      $	��23* �6+   �� 5?      $
��374* �6+   .+�5A        -   5        $ dgNoT��5B      $��
10,111,0,0q�5D       .   .  $��25(�5I      $
��Left=�5J      $	��Top=�5K      $
��1046��61   $	��262��6>   $��1��6K   ��5F      �� $
 loaddatabinding� 5L        5M      $ Number of Tickets��6\      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6w    .  61   �� $
 Number_of_Tickets�6�     5N      $ Category��6S   $ * 6e    .  61   �� $
 ass_user�6o     5O      $ Status��6O   $ * 6_    .  61   �� $

 stat�6i   5Q      �� 5R      -   5        $ lblNoT��5S      $��Number of Tickets��5T      $
��Left=�5U      $��
349,10,0,0q�5V      $	��Top=�5W      $	��358��5X      $
��Bold"�5Y      $��40(�5Z      $��1��6'   5\      5]      �� 5_      $��Open and Resolved Tickets��6   $��20(�69   .��5`      � ���	#FFE5E5E5 5a      �� 5b      $
��161* �6+   �� 5c      $
��223* �6+   �� 5d      $
��410* �6+   .+�5g        -   5        $ dgOaR��5h      $��29,133,29,421q�5j       .   .  $��3��5o      $��18(�5p      $	 Extended=�6'   ��5l      �� *loaddatabinding+ 5q        5r      $ 	Ticket ID��6T    .  61   �� $
 	ticket_id�6g     5s      $ Status��6O    .  61   �� $

 stat�6_     5t      $ Customer Name��6T    .  61   �� $
 	cust_name�6k     5u      $ Problem Title��6U    .  61   �� $
 
prob_title�6l     5v      $ Assgined User��6S    .  61   �� $
 ass_user�6j     5w      $ 	Solved By��6R    .  61   �� $
 solu_by�6e     5x      $ Ticket Created��6S    .  61   �� $
 datetime�6k     5y      $ Solved Date��6T    .  61   �� $
 	solved_on�6i   5{        5}      -   5        $ dgOaR2��5}      $��29,384,29,170q�5       .   .  $��18(�5�   D   $��3��6R   ��5�      �� *loaddatabinding+ 5�        5�      $ 	Ticket ID��6T    .  61   �� $
 	ticket_id�6g     5�      $ Status��6O   $ * 6_    .  61   �� $

 stat�6i     5�      $ Customer Name��6T   $ * 6k    .  61   �� $
 	cust_name�6u     5�      $ Problem Title��6U   $ * 6l    .  61   �� $
 
prob_title�6v     5�      $ Assigned User��6S   $ * 6j    .  61   �� $
 ass_user�6t     5�      $ Ticket Created��6S   $ * 6k    .  61   �� $
 datetime�6u   5�      �� 5�      -   5        $ lblOaR��5�      $��Open and Resolved Tickets��5�      $
��Left=�5�      $��
100,10,0,0q�5�      $	��Top=�5�      $	��510��5�      $
��Bold"�5�      $��40(�5�      $��1��6'   $��2��67   �� 5�      -	   5        $ 	lblSolved��5�      $��Solved Tickets��5�      $
��Left=�5�      $��
125,78,0,0q�5�      $	��Top=�5�      $��30(�5�      $
��Bold"�5�      $��2��5�      $	��460��5�      $��50��5�      $��Center=�5�      $��1��6=   �� 5�      -
   5        $ 
lblPending��5�      $��Pending Tickets��5�      $
��Left=�5�      $��231,329,0,0q�5�      $	��Top=�5�      $��30(�5�      $
��Bold"�6'   $��1��69   $	��247��6I   $��50��6U   $��2��6a   5�      5�      �� 5�      $
��User��6   $��20(�6$   .��5�      � ���	#FFE5E5E5 5�      �� 5�      $	��59* �6+   �� 5�      $
��735* �6+   .+�5�        -   5        $ dgUser��5�      $��30,72,338,197q�5�       .   .  $��2��5�      $��30(�5�   D   ��5�      �� *loaddatabinding+ 5�        5�      $ EmpID��6P    .  61   �� $
 EmpID�6_     5�      $
 Name��6O    .  61   �� $

 Name�6]     5�      $ Username��6S    .  61   �� $
 Username�6e     5�      $ 
Permission��6U    .  61   �� $
 
Permission�6i     5�      $ AddedOn��6R    .  61   �� $
 AddedOn�6c   5�      �� 5�      -   5         ��Name$ bUserConfirm��5�      $��Confirm��5�      $
��Left=�5�      $��846,498,0,0q�5�      $	��Top=�5�      $��50��5�      $	��178��5�      $��30(�5�      $��Normal"�5�      $��1��6-   �� 5�      -   5         ��Name$ cbUser��5�      $
��Left=�5�      $��820,127,0,0q�5�      $	��Top=�5�      $	��230��5�      $��1��6%   $��Center=�5�      $��50��5�   D   $��30(�6P   �� 5�      -   5        $ cbPermission��5�      $
��Left=�5�      $��820,340,0,0q�5�      $	��Top=�5�      $	��230��5�      $��1��6%   $��Center=�5�      $��50��5�   J   $��30(�6V   .@�5�      �� $��Admin��6'   69   �� 5�      $��Staff��6'   69   �� 5�      $
��User��6'   68   5�      �� 5�      -   5        $ lblUser��5�      $��User Permission��5�      $
��Left=�5�      $��
351,12,0,0q�5�      $	��Top=�5�      $	��314��5�      $
��Bold"�5�      $��40(�5�      $��1��6'   �� 5�      -   5        $ 	lblUsercb��5�      $
��User��5�      $
��Left=�5�      $��
894,72,0,0q�5�      $	��Top=�5�      $��Center=�5�      $��30(�5�      $��Normal"�6'   $��1��6;   $��83��6K   $��50��6V   �� 5�      -   5        $ lblSolution��5�      $��1��5�      $��
Permission��5�      $
��Left=�5�      $��857,285,0,0q�5�      $	��Top=�5�      $��30(�5�      $��Normal"�6'   $	��157��6;   $��50��6G   5�      5�      5�      �� 5  
   -   5        $ 	btnLogout��5     $��Logout��5     $
��Left=�5     $��917,682,0,0q�5     $	��Top=�5     $��50��5     $	��230��6   $��30(�5     $
��Bold"�5	     5
     5     5     