
# this import must be built from f# core project. For any changes to be recognized you must transpile the f# project first.
from ProjectNameVar.main import Main

class TestProjectNameVar:

  def test_1(self):
    Main.hello("{GITOWNER}")
    assert 1 == 1

  def test_2(self):
    Main.hello("{GITOWNER}", "Kevin")
    assert 1 == 1

  def test_3(self):
    Main.print_tuples([("a", "b"), ("c", "d")])
    assert 1 == 1