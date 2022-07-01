# TODO
import json
import jsonpickle

from src.model.simulation_parameters import SimulationParameters


class Model:
    def __init__(self, filename):
        self.filename = filename
        self.params = SimulationParameters()

    def toJSON(self):
        return json.dumps(self.params, default=lambda o: o.__dict__, indent=4)

    def save(self):
        if self.filename is not None:
            with open(self.filename, 'w') as ktlFile:
                ktlFile.write(jsonpickle.encode(self.params))
                ktlFile.close()
        else:
            raise FileNotFoundError()

    def open(self):
        if self.filename is not None:
            with open(self.filename, 'r') as ktlFile:
                self.params = jsonpickle.decode(ktlFile.read())
                ktlFile.close()
        else:
            raise FileNotFoundError()

    def is_empty(self):
        return bool(self.params.tower_list)

    def empty(self):
        self.params = SimulationParameters()
