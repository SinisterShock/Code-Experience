# TODO
from src.model.tower import Tower


class SimulationParameters:
    def __init__(self):
        self.tower_list = []

        # TODO test code remove!
        # if len(self.tower_list) == 0:
        #     for i in range(0, 4):
        #         self.add_tower(Tower(i + 1, 0.520, 64.00, 0.00, 0.00, 0, 70.8, 0.0))

    def add_new_tower(self):
        if len(self.tower_list) > 0:
            new_id = max(tower.tower_num for tower in self.tower_list) + 1
        else:
            new_id = 1

        tower = Tower(new_id, 0.0, 0.00, 0.00, 0.00, 0, 0.0, 0.0)
        self.tower_list.append(tower)

        return tower

    def remove_tower(self, tower):
        self.remove_tower(tower)

    def num_towers(self):
        return len(self.tower_list)
