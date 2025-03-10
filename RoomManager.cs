using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject[] theDoors;
    private Dungeon theDungeon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Core.thePlayer = new Player("Mike");
        this.theDungeon = new Dungeon();
        this.setupRoom();
    }

    //disable all doors
    private void resetRoom()
    {
        this.theDoors[0].SetActive(false);
        this.theDoors[1].SetActive(false);
        this.theDoors[2].SetActive(false);
        this.theDoors[3].SetActive(false);
    }

    //show the doors appropriate to the current room
    private void setupRoom()
    {
        Room currentRoom = Core.thePlayer.getCurrentRoom();
        this.theDoors[0].SetActive(currentRoom.hasExit("north"));
        this.theDoors[1].SetActive(currentRoom.hasExit("south"));
        this.theDoors[2].SetActive(currentRoom.hasExit("east"));
        this.theDoors[3].SetActive(currentRoom.hasExit("west"));
    }
    public class Room
{
    private Dictionary<string, Room> exits;

    public Room()
    {
        exits = new Dictionary<string, Room>();
    }

    public void setExit(string direction, Room neighbor)
    {
        exits[direction] = neighbor;
    }

    public bool hasExit(string direction)
    {
        return exits.ContainsKey(direction);
    }

    public Room getExit(string direction)
    {
        if (exits.ContainsKey(direction))
        {
            return exits[direction];
        }
        return null;
    }

    public bool tryToTakeExit(string direction)
    {
        if (exits.ContainsKey(direction))
        {
            Core.thePlayer.setCurrentRoom(exits[direction]);
            return true;
        }
        return false;
    }
}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            //try to goto the north
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //try to goto the west
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            //try to goto the east
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            //try to goto the south
        }
    }
}
