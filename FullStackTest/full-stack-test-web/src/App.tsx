import {} from "@chakra-ui/icons";
import { Container, Heading, SimpleGrid } from "@chakra-ui/react";
import { DndProvider } from "react-dnd";
import { HTML5Backend } from "react-dnd-html5-backend";
import Column from "./components/Column";
import DarkModeIconButton from "./components/DarkModeIconButton";
import { ColumnType } from "./utils/enums";
import { useEffect, useState } from "react";
import Skeleton, { SkeletonTheme } from "react-loading-skeleton";
import { Search } from "./components/Search";

function App() {
  const [loading, setLoading] = useState(true);
  const [inputValue, setInputValue] = useState(" ");

  useEffect(() => {
    setTimeout(() => {
      setLoading(false);
    }, 5000);
  }, []);

  const loader = () => {
    return (
      <main>
        <Heading
          fontSize={{ base: "4xl", sm: "5xl", md: "6xl" }}
          fontWeight="bold"
          textAlign="center"
          bgGradient="linear(to-l, #000000, #FF0080)"
          bgClip="text"
          mt={4}
        >
          FullStack Test Kanban Board
        </Heading>
        <DarkModeIconButton position="absolute" top={0} right={2} />

        <DndProvider backend={HTML5Backend}>
          <Container maxWidth="container.lg" px={4} py={10}>
            <SimpleGrid
              columns={{ base: 1, md: 3 }}
              spacing={{ base: 16, md: 3 }}
            >
              <SkeletonTheme>
                <Skeleton count={10} />
              </SkeletonTheme>
              <SkeletonTheme>
                <Skeleton count={10} />
              </SkeletonTheme>
              <SkeletonTheme>
                <Skeleton count={10} />
              </SkeletonTheme>
            </SimpleGrid>
          </Container>
        </DndProvider>
      </main>
    );
  };

  if (loading) {
    return loader();
  } else {
    return (
      <main>
        <Heading
          fontSize={{ base: "4xl", sm: "5xl", md: "6xl" }}
          fontWeight="bold"
          textAlign="center"
          bgGradient="linear(to-l, #000000, #FF0080)"
          bgClip="text"
          mt={4}
        >
          FullStack Test Kanban Board
        </Heading>
        <DarkModeIconButton position="absolute" top={0} right={2} />
        <Search
          onChange={(e: React.ChangeEvent<HTMLInputElement>) => {
            setInputValue(e.target.value);
          }}
        />
        <DndProvider backend={HTML5Backend}>
          <Container maxWidth="container.lg" px={4} py={10}>
            <SimpleGrid
              columns={{ base: 1, md: 3 }}
              spacing={{ base: 16, md: 3 }}
            >
              <Column column={ColumnType.TO_DO} titulo={inputValue} />
              <Column column={ColumnType.IN_PROGRESS} titulo={inputValue} />
              <Column column={ColumnType.COMPLETED} titulo={inputValue} />
            </SimpleGrid>
          </Container>
        </DndProvider>
      </main>
    );
  }
}

export default App;