   M S B A M L   `   `   `  ����I  EClientLourdWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ClientLourdWpfClientLourdWpf  5      "    ClientLourdWpf.customersList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:ClientLourdWpf     5        N� Title$  customersList��5	      $	��433��6   .��5      � -   5        
�������.+�5   
   ]� $	��400��6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5         AutoGenerateColumns .     EnableRowVirtualization . $	��400��6d   $	��610��6q   $��10,0,0,0q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        lastName��,  &System.Windows.Controls.DataGridColumn   Header$	 Nom��5   X      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6e   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *
lastName+6e     5      -   5        	firstName��$ Prénom��5   Z   $ * 6j    6<   �� *	firstName+6j     5      -   5        mail��$
 Mail��5   P   $ * 6^    67   �� *mail+6^     5      -   5        phoneNumber��$
 Tel.��5   ^   $ * 6l    6>   �� *phoneNumber+6l     5      -   5        
budget��$ Budget��5   T   $ * 6d    69   �� *budget+6d     5      -   5        subject��$ Sujet��5   V   $ * 6e    6:   �� *	subject+6e   5      �� 5      $	��150��6   $	��400��6%   $��5,0,0,0q�62   .+�5      �� $��Center=�6   $
��Wrap=�6:   $��Nom :��6N   $	��Top=�6[   �� 5      -	   5         ��Name$ editLastName��5      $��Right=�60   $��23��6L   	 �� TextWrapping$
	 Wrap=�6X   $	��Top=�6m   $	��140��6�   $��0,0,5,0q�6�   ��6�   �� *
lastName+6�   �� 5      $��Center=�6   $
��Wrap=�69   $��	Prénom :��6M   $	��Top=�6]   �� 5      -
   5        $ editFirstName��5      $��Right=�62   $��23��6N   $
	 Wrap=�6[   $	��Top=�6�   $	��140��6�   $��0,0,5,0q�6�   ��6o   �� 
 �� Path$
 	firstName�6�   �� 5      $��Center=�6   $
��Wrap=�6:   $��Mail :��6N   $	��Top=�6\   �� 5      -   5        $ editMail��5      $��Right=�6-   $��23��6I   $
	 Wrap=�6U   $	��Top=�6�   $	��140��6�   $��0,0,5,0q�6�   ��6i   �� $

 mail�6�   �� 5      $��Center=�6   $
��Wrap=�69   $��Tel. :��6M   $	��Top=�6[   �� 5       -   5        $ editPhoneNumber��5       $��Right=�63   $��23��6O   $
	 Wrap=�6[   $	��Top=�6�   $	��140��6�   $��0,0,5,0q�6�   ��6o   �� $
 phoneNumber�6�   �� 5!      $��Center=�6   $
��Wrap=�6:   $��Budget :��6N   $	��Top=�6^   �� 5"      -   5        $ 
editBudget��5"      $��Right=�6.   $��23��6J   $
	 Wrap=�6V   $	��Top=�6�   $	��140��6�   $��0,0,5,0q�6�   ��6j   �� $
 budget�6�   �� 5#      $��Center=�6   $
��Wrap=�69   $��Sujet :��6M   $	��Top=�6\   �� 5$      -   5        $ editSubject��5$      $��Right=�6/   $��80��6K   $
	 Wrap=�6W   $	��Top=�6�   $	��140��6�   $��0,0,5,0q�6�   ��6k   �� $
 subject�6�   ]� 5%      $	��100��6   $��0,10,0,0q�6)   .+�5&      �� -   5        $��Modifier��5&      $��70��6E   $��0,0,5,0q�6P   ���	#FF00B230$
��Bold"�6x   �� 5'      -   5        $��	Supprimer��5'      $��0q�61   ���	#FFF90B0B$
��Bold"�6S   6e   5(      5)      5*      5+      5,      