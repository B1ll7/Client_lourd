   M S B A M L   `   `   `  ����I  EClientLourdWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ClientLourdWpfClientLourdWpf  5      #    ClientLourdWpf.addAppointment   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:ClientLourdWpf     5        N� Title$  addAppointment��5	      .��5      � -   5        .+�5   
   �� $��40��6   $��
0,-410,0,0q�6     �� TextAlignment$ Center=�64   $��20(�6K   
���   �
�������$
��Bold"�6   $��Center=�6�   Ajouter un rendez-vous6�   �� 5   
   $	��300��6   .+�5      �� $��Center=�6   .��61   Choisir client :6C   �� 5      -   5         ��Name$ comboboxCustomer��5   /   $��30��6   $	��200��6#    �� DisplayMemberPath$ lastName��6I    �� SelectedValuePath$ 
idCustomer��6f   �� 5      $��Center=�6   .��61   Choisir courtier :6E   �� 5      -   5        $ comboboxBroker��5   0   $��30��6   $	��200��6#   $ lastName��6I   $ idBroker��6f   (  "System.Windows.Controls.DatePicker  5      -   5          Name$
 date��5   G   $��30��6   $	��200��6)   $��0,10,0,0q�65   6G   ]� 5      $	��200��6   .+�5      �� $��0,0,10,0q�6   .��6*   Heure61   �� 5      $��70,0,0,0q�6   .��6+   Min60   5      ]� 5      $��Center=�6   .+�5      �� -   5         ��Name$
 Hour��5      $��20��6(   $	��100��65   $��0,0,10,0q�6A    �� 	MaxLength$ 2��6t   �� 5      -   5        $	 Min��5      $��20��6'   $	��100��64   $ 2��6a   5      ]� 5       $	��300��6   $��0,10,0,0q�6$   $��Center=�66   .+�5!      �� $	��100��6   $��35,0,0,0q�6%   
���  ��
�������$
��Bold"�6[   .��6m   	Annuler6v   �� 5"      -   5        $	��100��5"      
�������
��� � �$
��Bold"�6K   .��6r   Enregistrer6   5#      5$      5%      5&      