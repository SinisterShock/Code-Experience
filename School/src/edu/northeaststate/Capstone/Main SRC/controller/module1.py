from src.view.module1 import Module1


class Module1Controller:
    def __init__(self, model, view):
        self.model = model
        self.view = view

    def create_view(self):
        # create module1 view
        self.view.module1_view = Module1(self.view, self)
        self.view.module1_view.state(newstate='normal')

        self.refresh_tree()

    def toggle(self):
        if self.view.module1_view.state() == 'normal':
            self.view.module1_view.withdraw()
        else:
            self.view.module1_view.deiconify()

    def destroy_view(self):
        self.view.module1_view.destroy()

    def close_view(self):
        self.view.module1_view.withdraw()

    def add_tower(self):
        # create a tower object
        t = self.model.params.add_new_tower()

        self.view.module1_view.frame.tree.insert('', 'end', iid=t.tower_num, values=(
            t.tower_num, t.ratio, t.phase, t.spacing_deg, t.orient_deg, t.reference_tower, t.height_deg,
            t.top_load_deg))

        self.view.module1_view.frame.tree.focus(t.tower_num)
        self.view.module1_view.frame.tree.selection_set(t.tower_num)

    def clear_tree(self):
        for item in self.view.module1_view.frame.tree.get_children():
            self.view.module1_view.frame.tree.delete(item)

    def refresh_tree(self):
        self.clear_tree()

        # add all values from towers
        for t in self.model.params.tower_list:
            self.view.module1_view.frame.tree.insert('', 'end', iid=t.tower_num, values=(
                t.tower_num, t.ratio, t.phase, t.spacing_deg, t.orient_deg, t.reference_tower, t.height_deg,
                t.top_load_deg))

    def tree_item_double_clicked(self, event):
        print(event, self.view.module1_view.frame.tree.selection(), self.view.module1_view.frame.tree.focus())
        # TODO: Fill Entry Fields
        curItem = self.view.module1_view.frame.tree.item(self.view.module1_view.frame.tree.focus())
        print(curItem)

        # def save(self, email):
    #     try:
    #         # save the model
    #         self.model.email = email
    #         self.model.save()
    #
    #         # show a success message
    #         self.view.show_success(f'The email {email} saved!')
    #
    #     except ValueError as error:
    #         # show an error message
    #         self.view.show_error(error)
